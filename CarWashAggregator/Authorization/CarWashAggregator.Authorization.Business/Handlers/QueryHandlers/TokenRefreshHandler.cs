using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.Handlers.QueryHandlers
{
    public class TokenRefreshHandler : IQueryHandler<RequestTokenRefresh, ResponseUserAuthorization>
    {
        private readonly IAuthorizationManager _authorizationManager;

        public TokenRefreshHandler(IAuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        public async Task<ResponseUserAuthorization> Handle(RequestTokenRefresh request)
        {
            var refreshToken = request.RefreshToken;

            var jwAuthResult = await _authorizationManager.RefreshAccessTokenAsync(refreshToken);

            return new ResponseUserAuthorization()
            {
                Success = jwAuthResult.Success,
                AccessToken = jwAuthResult.AccessToken,
                RefreshToken = jwAuthResult.RefreshToken,
                AuthFailure = (AuthFailure)jwAuthResult.AuthFailure
            };
        }
    }
}
