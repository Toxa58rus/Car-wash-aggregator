using System;

namespace CarWashAggregator.ApiGateway.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}