using System;

namespace CarWashAggregator.Authorization.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}