namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
{
    public enum ValidationFailure
    {
        None,
        InvalidLifetime,
        InvalidToken
    }
}
