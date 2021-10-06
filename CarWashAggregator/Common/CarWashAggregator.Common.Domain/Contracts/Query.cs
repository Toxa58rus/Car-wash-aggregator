using System;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public abstract class Query
    {
        public DateTime Timestamp { get; protected set; }
        protected Query()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
