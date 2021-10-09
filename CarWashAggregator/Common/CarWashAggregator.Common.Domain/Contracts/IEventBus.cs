using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IEventBus
    {
        public Task<T> RequestQueryAsync<T>(T request) where T : Query;

        void ReplyToQuery<T>(T reply, string replyingQueue, string correlationId, ulong deliveryTag) where T : Query;

        void SubscribeToEvent<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
        void SubscribeToQuery<T, TH>()
            where T : Query
            where TH : IQueryHandler<T>;
    }
}

