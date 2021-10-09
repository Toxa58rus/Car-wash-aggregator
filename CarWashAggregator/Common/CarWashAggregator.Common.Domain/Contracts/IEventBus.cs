using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IEventBus
    {
        Task<T> RequestQuery<T>(T request) where T : Query;

        void PublishEvent<T>(T @event) where T : Event;

        void SubscribeToEvent<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;

        void SubscribeToQuery<T, TH>()
            where T : Query
            where TH : IQueryHandler<T>;
    }
}