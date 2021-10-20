namespace CarWashAggregator.ApiGateway.Domain.Models
{
    public class UserModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
    }
}