using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Response
{
    public class ResponseGetUser : Query
    {
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }
    }
}
