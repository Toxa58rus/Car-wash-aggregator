using System;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseTokenValidationCheck : Query
    {
        public Guid? UserId { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
