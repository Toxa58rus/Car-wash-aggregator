namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
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
