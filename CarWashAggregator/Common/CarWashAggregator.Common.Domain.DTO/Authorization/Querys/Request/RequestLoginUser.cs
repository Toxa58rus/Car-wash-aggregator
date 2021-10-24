using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestLoginUser : Query
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
    }
}
