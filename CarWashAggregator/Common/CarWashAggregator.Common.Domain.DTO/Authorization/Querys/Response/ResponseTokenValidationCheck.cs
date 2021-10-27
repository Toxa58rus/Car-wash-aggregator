using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseTokenValidationCheck : Query
    {
        public Guid AuthId { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
