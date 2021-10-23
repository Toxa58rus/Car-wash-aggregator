namespace CarWashAggregator.ApiGateway.Domain.Models.Authorization
{
    public enum AuthFailure
    {
        None,
        UserDoesNotExist,
        UserAlreadyExist,
        TokenNotValid,
        RequestNotValid,
        ServerError
    }
}
