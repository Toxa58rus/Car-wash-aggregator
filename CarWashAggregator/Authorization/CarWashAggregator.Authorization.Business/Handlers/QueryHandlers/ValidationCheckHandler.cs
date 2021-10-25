using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.Handlers.QueryHandlers
{
    public class ValidationCheckHandler : IQueryHandler<RequestTokenValidationCheck, ResponseTokenValidationCheck>
    {
        private readonly IAuthorizationManager _authorizationManager;

        public ValidationCheckHandler(IAuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        public async Task<ResponseTokenValidationCheck> Handle(RequestTokenValidationCheck request)
        {
            var validationResult = await _authorizationManager.ValidateAccessToken(request.TokenToValidate);

            return new ResponseTokenValidationCheck()
            {
                UserId = validationResult.UserId,
                ValidationFailure = (ValidationFailure)validationResult.ValidationFailure
            };
        }
    }
}
