using System;

namespace CarWashAggregator.Orders.Domain.Models
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
