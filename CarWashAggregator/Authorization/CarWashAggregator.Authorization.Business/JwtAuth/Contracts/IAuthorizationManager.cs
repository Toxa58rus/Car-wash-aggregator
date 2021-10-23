using CarWashAggregator.Authorization.Business.JwtAuth.Models;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.JwtAuth.Contracts
{
    public interface IAuthorizationManager
    {
        Task<JwtAuthResult> RegisterAsync(string login, string password, int role);
        Task<JwtAuthResult> LoginAsync(string login, string password, int role);
        Task<JwtAuthResult> RefreshAccessTokenAsync(string refreshToken);

        Task<JwtValidationResult> ValidateAccessToken(string token);
    }
}