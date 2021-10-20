namespace CarWashAggregator.ApiGateway.Domain.Models.Authorization
{
    public class ValidationResponse
    {
        public ValidationFailure ValidationFailure { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
    }
}
