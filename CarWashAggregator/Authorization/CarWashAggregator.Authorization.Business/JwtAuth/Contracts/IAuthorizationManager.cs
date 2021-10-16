using CarWashAggregator.Authorization.Business.JwtAuth.Models;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.JwtAuth.Contracts
{
    public interface IAuthorizationManager
    {
        Task<JwtAuthResult> RegisterAsync(string login, string password, string role);
        Task<JwtAuthResult> LoginAsync(string login, string password, string role);
        Task<JwtAuthResult> RefreshTokenAsync(string accessToken, string refreshToken);
        bool ValidateJwtToken(string token);
    }
}
