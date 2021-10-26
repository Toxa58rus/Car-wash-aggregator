using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}