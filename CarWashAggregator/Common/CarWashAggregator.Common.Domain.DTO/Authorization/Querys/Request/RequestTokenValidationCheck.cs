using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestTokenValidationCheck : Query
    {
        public string TokenToValidate { get; set; }
    }
}
