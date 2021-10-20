namespace CarWashAggregator.ApiGateway.Domain.Models.Authorization
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AuthFailure AuthFailure { get; set; }
    }
}
