namespace CarWashAggregator.Orders.Domain.Contracts
{
    public interface IEventBus
    {
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}

