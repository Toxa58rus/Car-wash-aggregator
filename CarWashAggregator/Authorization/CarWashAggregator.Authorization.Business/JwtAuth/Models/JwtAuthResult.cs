namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AuthFailure AuthFailure { get; set; }
    }
}