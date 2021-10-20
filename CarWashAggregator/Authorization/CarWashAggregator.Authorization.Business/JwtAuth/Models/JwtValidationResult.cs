namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
{
    public class JwtValidationResult
    {
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
