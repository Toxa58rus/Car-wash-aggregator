using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestTokenRefresh : Query
    {
        public string RefreshToken { get; set; }
    }
}
