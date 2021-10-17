using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseUserAuthorization : Query
    {
        public IssuedTokensDTO IssuedTokens { get; set; }
        public string Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
