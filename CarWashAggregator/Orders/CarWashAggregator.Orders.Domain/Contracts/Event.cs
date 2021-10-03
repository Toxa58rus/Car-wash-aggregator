using System;

namespace CarWashAggregator.Orders.Domain.Contracts
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
