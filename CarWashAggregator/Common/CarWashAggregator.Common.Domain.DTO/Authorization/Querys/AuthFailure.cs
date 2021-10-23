namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys
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
