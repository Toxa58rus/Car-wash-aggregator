using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.Authorization
{
    public class ValidationResponse
    {
        public Guid AuthId { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
