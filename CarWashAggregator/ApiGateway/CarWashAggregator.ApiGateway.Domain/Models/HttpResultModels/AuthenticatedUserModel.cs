namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
    public class AuthenticatedUserModel
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
