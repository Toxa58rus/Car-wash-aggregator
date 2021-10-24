namespace CarWashAggregator.ApiGateway.Domain.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}