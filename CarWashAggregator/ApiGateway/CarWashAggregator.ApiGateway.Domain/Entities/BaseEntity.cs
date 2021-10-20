using System;

namespace CarWashAggregator.ApiGateway.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
