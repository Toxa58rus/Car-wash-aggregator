using CarWashAggregator.Common.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Common.Infra.Bus
{
    public class BusBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ConnectionFactory _connectionFactory;
        private readonly static Dictionary<string, Type> _messageHandlers = new Dictionary<string, Type>();
        private readonly static List<Type> _messageTypes = new List<Type>();

        protected BusBase(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _connectionFactory = new ConnectionFactory()
            {
                HostName = configuration.GetConnectionString("Bus"),
                DispatchConsumersAsync = true
            };
        }


        protected void Publish(byte[] messageBytes, string routingKey, bool awaitingReply = false)
        {
            var connection = _connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            if (awaitingReply)
            {
                var props = channel.CreateBasicProperties();
                var replyQueueName = channel.QueueDeclare().QueueName;
                var correlationId = Guid.NewGuid().ToString();
                props.CorrelationId = correlationId;
                props.ReplyTo = replyQueueName;
                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.Received += async (model, ea) =>
                {
                    if (ea.BasicProperties.CorrelationId != correlationId)
                        return;

                    var messageType = _messageTypes.SingleOrDefault(t => t.Name == routingKey);
                    var handler = GetHandler(routingKey);
                    var body = ea.Body.ToArray();
                    var response = Encoding.UTF8.GetString(body);
                    var message = JsonConvert.DeserializeObject(response, messageType);
                    var concreteType = typeof(IReturnedQueryHandler<>).MakeGenericType(messageType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { message });
                    connection.Close();
                };

                channel.BasicConsume(consumer, replyQueueName, autoAck: true);
                channel.BasicPublish("", routingKey, props, messageBytes);
                return;
            }

            channel.QueueDeclare(routingKey, false, false, false, null);
            channel.BasicPublish("", routingKey, null, messageBytes);
            connection.Close();
        }

        private object GetHandler(string messageTypeName)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var subscription = _messageHandlers[messageTypeName];
                var handler = scope.ServiceProvider.GetService(subscription);
                return handler;
            }
        }

        protected void Reply(byte[] messageBytes, string routingKey, string correlationId, ulong deliveryTag)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var props = channel.CreateBasicProperties();
                    props.CorrelationId = correlationId;

                    channel.BasicPublish("", routingKey, props, messageBytes);
                    channel.BasicAck(deliveryTag, false);
                }
            }
        }

        protected void Subscribe<T, TH>()
        {
            var messageType = typeof(T);
            var handlerType = typeof(TH);
            _messageHandlers.Add(messageType.Name, handlerType);
            _messageTypes.Add(messageType);
            StartBasicConsume(messageType.Name);
        }

        private void StartBasicConsume(string routingKey)
        {
            var connection = _connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(routingKey, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                await ProcessMessage(ea).ConfigureAwait(false);
            };
            channel.BasicConsume(
                        consumer: consumer,
                        queue: routingKey,
                        autoAck: false);
        }

        protected async Task ProcessMessage(BasicDeliverEventArgs deliveredArgs)
        {
            var messageTypeName = deliveredArgs.RoutingKey;

            if (_messageHandlers.ContainsKey(messageTypeName))
            {
                var handler = GetHandler(messageTypeName);
                var messageType = _messageTypes.SingleOrDefault(t => t.Name == messageTypeName);
                var props = deliveredArgs.BasicProperties;
                var body = deliveredArgs.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject(response, messageType);

                if (props.ReplyTo is null)
                {
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(messageType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { message });
                }
                else
                {
                    var concreteType = typeof(IRequestedQueryHandler<>).MakeGenericType(messageType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { message, props.ReplyTo, props.CorrelationId, deliveredArgs.DeliveryTag });
                }
            }
        }

    }
}