using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request
{
    public class RequestRegisterNewUser : Query
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRole { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
