using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseTokenValidationCheck : Query
    {
        public ValidationFailure ValidationFailure { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
    }
}
