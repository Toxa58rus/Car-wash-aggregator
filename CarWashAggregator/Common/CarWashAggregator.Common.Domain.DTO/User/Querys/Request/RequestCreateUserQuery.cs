using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Request
{
    public class RequestCreateUserQuery : Query
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public string Role { get; set; }
    }
}
