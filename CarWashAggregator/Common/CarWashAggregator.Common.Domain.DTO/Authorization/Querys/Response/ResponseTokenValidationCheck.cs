using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseTokenValidationCheck : Query
    {
        public bool TokenIsValid { get; set; }
    }
}
