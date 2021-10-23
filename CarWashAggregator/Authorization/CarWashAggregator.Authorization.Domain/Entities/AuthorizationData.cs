namespace CarWashAggregator.Authorization.Domain.Entities
{
    public class AuthorizationData : BaseEntity
    { 
        public string UserLogin { get; set; }
        public string HashPassword { get; set; }
        public string RefreshToken { get; set; }
    }
}