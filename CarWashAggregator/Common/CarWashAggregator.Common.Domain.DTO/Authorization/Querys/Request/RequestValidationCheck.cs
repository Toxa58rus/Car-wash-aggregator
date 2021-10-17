using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestValidationCheck : Query
    {
        public string TokenToValidate { get; set; }
    }
}
