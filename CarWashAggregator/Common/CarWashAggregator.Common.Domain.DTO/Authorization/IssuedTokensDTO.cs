namespace CarWashAggregator.Common.Domain.DTO.Authorization
{
    public class IssuedTokensDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}