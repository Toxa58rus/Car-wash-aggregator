using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.Handlers.QueryHandlers
{
    public class ValidationCheckHandler : IQueryHandler<RequestValidationCheck, ResponseValidationCheck>
    {
        private readonly IAuthorizationManager _authorizationManager;

        public ValidationCheckHandler(IAuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        public Task<ResponseValidationCheck> Handle(RequestValidationCheck request)
        {
            var tokenIsValid = new ResponseValidationCheck()
            {
                TokenIsValid = _authorizationManager.ValidateJwtToken(request.TokenToValidate)
            };
            return Task.FromResult(tokenIsValid);
        }
    }
}
