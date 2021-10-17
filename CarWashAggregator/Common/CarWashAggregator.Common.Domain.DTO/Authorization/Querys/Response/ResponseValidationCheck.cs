using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseValidationCheck : Query
    {
        public bool TokenIsValid { get; set; }
    }
}
