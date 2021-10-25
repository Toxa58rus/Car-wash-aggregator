using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.Authorization
{
    public class ValidationResponse
    {
        public Guid UserId { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
