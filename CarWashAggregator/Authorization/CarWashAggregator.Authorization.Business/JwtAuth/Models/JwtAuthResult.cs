namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
{
    public class JwtAuthResult
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Error { get; set; }
    }
}