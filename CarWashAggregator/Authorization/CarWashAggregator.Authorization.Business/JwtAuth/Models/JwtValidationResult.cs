using System;

namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
{
    public class JwtValidationResult
    {
        public Guid? UserId { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
