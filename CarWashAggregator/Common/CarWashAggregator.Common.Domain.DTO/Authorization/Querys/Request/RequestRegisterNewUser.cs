using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestRegisterNewUser : Query
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}
