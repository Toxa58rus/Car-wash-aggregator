namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IEventBus
    {
        void RequestQuery<T>(T query) where T : Query;
        void ReplyToQuery<T>(T reply, string replyingQueue, string correlationId, ulong deliveryTag) where T : Query;

        void SubscribeToEvent<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
        void SubscribeToQuery<T, TH>()
            where T : Query
            where TH : IRequestedQueryHandler<T>;
    }
}

