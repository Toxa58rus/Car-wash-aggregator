using System;

namespace CarWashAggregator.Orders.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}