namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
    public class UserProfile
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}