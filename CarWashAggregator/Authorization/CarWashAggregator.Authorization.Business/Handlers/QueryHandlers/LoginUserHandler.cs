using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.Handlers.QueryHandlers
{
    public class LoginUserHandler : IQueryHandler<RequestLoginUser, ResponseUserAuthorization>
    {
        private readonly IAuthorizationManager _authorizationManager;

        public LoginUserHandler(IAuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        public async Task<ResponseUserAuthorization> Handle(RequestLoginUser request)
        {
            var login = request.UserEmail;
            var password = request.UserPassword;
            var role = request.UserRole;

            if (login is null || password is null || role is null)
                return new ResponseUserAuthorization() { AuthFailure = AuthFailure.RequestNotValid };

            var jwAuthResult = await _authorizationManager.LoginAsync(login, password, role);

            return new ResponseUserAuthorization()
            {
                AccessToken = jwAuthResult.AccessToken,
                RefreshToken = jwAuthResult.RefreshToken,
                AuthFailure = (AuthFailure)jwAuthResult.AuthFailure
            };
        }
    }
}
