using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestLoginUser : Query
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; } = string.Empty;
    }
}
