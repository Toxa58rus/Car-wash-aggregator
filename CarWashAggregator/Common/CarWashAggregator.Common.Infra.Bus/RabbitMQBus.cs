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
        public RabbitMQBus(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration) : base(serviceScopeFactory, configuration)
        {

        }

        public async Task<T> RequestQuery<T>(T request) where T : Query
        {
            var message = JsonConvert.SerializeObject(request);
            var body = Encoding.UTF8.GetBytes(message);
            var reply = await (base.PublishQuery(body, typeof(T).Name)) as T;
            return reply;
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
            base.Subscribe<T, TH>(false);
        }

        public void SubscribeToQuery<T, TH>()
          where T : Query
          where TH : IQueryHandler<T>
        {
            base.Subscribe<T, TH>(true);
        }

    }
}
