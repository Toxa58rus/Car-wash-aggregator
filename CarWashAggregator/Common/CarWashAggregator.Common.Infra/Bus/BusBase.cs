using CarWashAggregator.Common.Domain;
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
    internal class BusBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConnection _connection;
        private readonly Dictionary<string, Type> _messageHandlers;
        private readonly Dictionary<string, Type> _responseTypes;
        private readonly List<Type> _messageTypes;

        protected BusBase(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _messageHandlers = new Dictionary<string, Type>();
            _responseTypes = new Dictionary<string, Type>();
            _messageTypes = new List<Type>();
            _serviceScopeFactory = serviceScopeFactory;
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(configuration.GetConnectionString(Helper.BusConnectionSection)),
                DispatchConsumersAsync = true
            };
            _connection = connectionFactory.CreateConnection();
        }

        protected void Publish(byte[] messageBytes, string routingKey)
        {
            var channel = _connection.CreateModel();
            var props = channel.CreateBasicProperties();
            props.Persistent = true;
            channel.QueueDeclare(routingKey, true, false, false, null);
            channel.BasicPublish("", routingKey, props, messageBytes);
            channel.Close();
        }

        protected object PublishQuery(byte[] messageBytes, Type messageType)
        {
            var channel = _connection.CreateModel();
            var props = channel.CreateBasicProperties();
            var replyQueueName = channel.QueueDeclare().QueueName;
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;
            props.Persistent = true;
            var consumer = new AsyncEventingBasicConsumer(channel);
            var tcs = new TaskCompletionSource<object>();

            consumer.Received += async (model, ea) =>
            {
                if (ea.BasicProperties.CorrelationId != correlationId)
                    return;

                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                channel.Close();
                tcs.SetResult(response);
            };
            channel.BasicConsume(consumer: consumer, queue: replyQueueName, autoAck: false);
            channel.BasicPublish("", messageType.Name, props, messageBytes);

            return tcs.Task.GetAwaiter().GetResult();
        }

        protected void SubToEvent<T, TH>()
        {
            var messageType = typeof(T);
            var handlerType = typeof(TH);
            _messageHandlers.Add(messageType.Name, handlerType);
            _messageTypes.Add(messageType);
            StartBasicConsume(messageType.Name, false);
        }
        protected void SubToQuery<TRequest, TResponse, THandler>()
        {
            var messageType = typeof(TRequest);
            var responseType = typeof(TResponse);
            var handlerType = typeof(THandler);
            var messageTypeName = messageType.Name;
            _messageHandlers.Add(messageTypeName, handlerType);
            _messageTypes.Add(messageType);
            _responseTypes.Add(messageTypeName, responseType);
            StartBasicConsume(messageTypeName, true);
        }

        private void StartBasicConsume(string routingKey, bool qosEnabled)
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(routingKey, true, false, false, null);
            if (qosEnabled)
            {
                channel.BasicQos(0, 1, false);
            }

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                await ProcessMessage(model, ea).ConfigureAwait(false);
            };
            channel.BasicConsume(consumer: consumer, queue: routingKey, autoAck: false);
        }

        private async Task ProcessMessage(object sender, BasicDeliverEventArgs deliveredArgs)
        {
            var messageTypeName = deliveredArgs.RoutingKey;

            if (!_messageHandlers.ContainsKey(messageTypeName))
                return;

            var messageType = _messageTypes.SingleOrDefault(t => t.Name == messageTypeName);
            var deliveredProps = deliveredArgs.BasicProperties;
            var body = deliveredArgs.Body.ToArray();
            var deliver = Encoding.UTF8.GetString(body);
            var message = JsonConvert.DeserializeObject(deliver, messageType);
            var channel = ((AsyncEventingBasicConsumer)sender).Model;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var subscription = _messageHandlers[messageTypeName];
                var handler = scope.ServiceProvider.GetService(subscription);

                if (deliveredProps.ReplyTo is null)
                {
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(messageType);
                    await (concreteType.GetMethod("Handle").Invoke(handler, new object[] { message }) as Task)
                        .ConfigureAwait(false);
                    channel.BasicAck(deliveredArgs.DeliveryTag, false);
                }
                else
                {
                    var responseType = _responseTypes[messageTypeName];
                    var concreteType = typeof(IQueryHandler<,>).MakeGenericType(messageType, responseType);
                    var handleMsg = concreteType.GetMethod("Handle").Invoke(handler, new object[] { message }) as Task;
                    await handleMsg.ConfigureAwait(false);
                    var reply = (object)((dynamic)handleMsg).Result;
                    var response = JsonConvert.SerializeObject(reply);
                    var responseMessage = Encoding.UTF8.GetBytes(response);

                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = deliveredProps.CorrelationId;
                    replyProps.Persistent = true;
                    channel.BasicPublish("", deliveredProps.ReplyTo, replyProps, responseMessage);
                    channel.BasicAck(deliveredArgs.DeliveryTag, false);
                }
            }

        }

    }
}