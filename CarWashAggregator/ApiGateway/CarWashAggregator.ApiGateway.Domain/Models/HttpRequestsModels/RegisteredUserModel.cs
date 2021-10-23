namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestsModels
{
    public class RegisteredUserModel
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
