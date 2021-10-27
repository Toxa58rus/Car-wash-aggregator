using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.User.Events;
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
            var login = request.Email;
            var password = request.Password;
            var role = request.Role;

            if (login is null || password is null)
                return new ResponseUserAuthorization() { AuthFailure = AuthFailure.RequestNotValid };

            var jwtAuthResult = await _authorizationManager.RegisterAsync(login, password, role);

            if (jwtAuthResult.AuthFailure == JwtAuth.Models.AuthFailure.None)
            {
                _bus.PublishEvent(new UserRegisteredEvent()
                {
                    AuthId = jwtAuthResult.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    Role = request.Role,
                    City = request.City
                });
            }

            return new ResponseUserAuthorization()
            {
                AccessToken = jwtAuthResult.AccessToken,
                RefreshToken = jwtAuthResult.RefreshToken,
                AuthFailure = (AuthFailure)jwtAuthResult.AuthFailure
            };
        }
    }
}
