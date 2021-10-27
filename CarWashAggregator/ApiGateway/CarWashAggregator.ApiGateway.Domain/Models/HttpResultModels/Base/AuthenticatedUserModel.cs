namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base
{
    public class AuthenticatedUserModel
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
