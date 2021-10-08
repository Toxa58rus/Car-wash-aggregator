using CarWashAggregator.Common.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Common.Infra.Bus
{
    public sealed class RabbitMQBus : BusBase, IEventBus
    {
        public RabbitMQBus(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

        public async Task<T> RequestQueryAsync<T>(T request) where T : Query
        {
            var message = JsonConvert.SerializeObject(request);
            var body = Encoding.UTF8.GetBytes(message);
            var reply = (T)await base.PublishQuery(body, typeof(T).Name);
            return reply;
        }

        public void ReplyToQuery<T>(T reply, string routingKey, string correlationId, ulong deliveryTag) where T : Query
        {
            var message = JsonConvert.SerializeObject(reply);
            var body = Encoding.UTF8.GetBytes(message);

            base.ReplyQuery(body, routingKey, correlationId, deliveryTag);

        }

        public void PublishEvent<T>(T @event) where T : Event
        {
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            base.Publish(body, typeof(T).Name);
        }

        public void SubscribeToEvent<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            base.Subscribe<T, TH>();
        }

        public void SubscribeToQuery<T, TH>()
          where T : Query
          where TH : IQueryHandler<T>
        {
            base.Subscribe<T, TH>();
        }

    }
}
