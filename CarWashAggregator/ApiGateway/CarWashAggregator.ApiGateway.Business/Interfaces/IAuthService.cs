using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterNewUserAsync(UserModel user);
        Task<AuthResponse> LoginUserAsync(UserModel user);
        Task<AuthResponse> RefreshAccessTokenAsync(string refreshToken);
        Task<ValidationResponse> ValidateAccessTokenAsync(string accessToken);
    }
}