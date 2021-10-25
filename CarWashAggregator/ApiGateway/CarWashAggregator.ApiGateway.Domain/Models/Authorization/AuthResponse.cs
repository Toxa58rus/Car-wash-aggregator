using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.Authorization
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AuthFailure AuthFailure { get; set; }
    }
}
