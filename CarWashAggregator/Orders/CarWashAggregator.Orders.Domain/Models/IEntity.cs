using System;

namespace CarWashAggregator.Orders.Domain.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
    }
}