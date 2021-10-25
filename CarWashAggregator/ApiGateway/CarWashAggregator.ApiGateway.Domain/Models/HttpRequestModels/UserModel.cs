namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
    public class UserModel
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}