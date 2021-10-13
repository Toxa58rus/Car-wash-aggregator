using CarWashAggregator.Common.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Common.Infra.Bus
{
    internal sealed class RabbitMQBus : BusBase, IEventBus
    {
        public RabbitMQBus(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration) : base(serviceScopeFactory, configuration)
        {

        }

        public Task<TResponse> RequestQuery<TRequest, TResponse>(TRequest request) where TRequest : Query where TResponse : Query
        {
            var message = JsonConvert.SerializeObject(request);
            var body = Encoding.UTF8.GetBytes(message);
            var responseJson = base.PublishQuery(body, typeof(TRequest)) as string;
            var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
            return Task.FromResult(response);
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
            base.SubToEvent<T, TH>();
        }

        public void SubscribeToQuery<TRequest, TResponse, THandler>()
          where TRequest : Query
          where TResponse : Query
          where THandler : IQueryHandler<TRequest, TResponse>
        {
            base.SubToQuery<TRequest, TResponse, THandler>();
        }

    }
}
