using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Events;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.Handlers.QueryHandlers
{
    public class RegisterNewUserHandler : IQueryHandler<RequestRegisterNewUser, ResponseUserAuthorization>
    {
        private readonly IAuthorizationManager _authorizationManager;
        private readonly IEventBus _bus;


        public RegisterNewUserHandler(IAuthorizationManager authorizationManager, IEventBus bus)
        {
            _authorizationManager = authorizationManager;
            _bus = bus;
        }

        public async Task<ResponseUserAuthorization> Handle(RequestRegisterNewUser request)
        {
            var login = request.UserEmail;
            var password = request.UserPassword;
            var role = request.UserRole;

            if (login is null || password is null || role is null)
                return new ResponseUserAuthorization() { AuthFailure = AuthFailure.RequestNotValid };

            var jwtAuthResult = await _authorizationManager.RegisterAsync(login, password, role);

            if (jwtAuthResult.Success)
            {
                _bus.PublishEvent(new UserRegisteredEvent()
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    TelephoneNumber = request.TelephoneNumber,
                    UserEmail = request.UserEmail,
                    UserPassword = request.UserPassword,
                    UserRole = request.UserRole
                });
            }

            return new ResponseUserAuthorization()
            {
                Success = jwtAuthResult.Success,
                AccessToken = jwtAuthResult.AccessToken,
                RefreshToken = jwtAuthResult.RefreshToken,
                AuthFailure = (AuthFailure)jwtAuthResult.AuthFailure
            };
        }
    }
}
