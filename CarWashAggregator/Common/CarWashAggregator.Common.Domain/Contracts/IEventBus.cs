using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IEventBus
    {
        public Task<TResponse> RequestQuery<TRequest, TResponse>(TRequest request)
            where TRequest : Query where TResponse : Query;

        void PublishEvent<T>(T @event) where T : Event;

        void SubscribeToEvent<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;

        public void SubscribeToQuery<TRequest, TResponse, TH>()
            where TRequest : Query
            where TResponse : Query
            where TH : IQueryHandler<TRequest, TResponse>;
    }
}