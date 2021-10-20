using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseUserAuthorization : Query
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AuthFailure AuthFailure { get; set; }
    }
}
