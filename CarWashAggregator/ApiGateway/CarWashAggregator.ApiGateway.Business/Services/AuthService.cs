using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;

        public AuthService(IEventBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        public async Task<AuthResponse> RegisterNewUserAsync(UserModel user)
        {
            var request = _mapper.Map<RequestRegisterNewUser>(user);
            var response = await _bus.RequestQuery<RequestRegisterNewUser, ResponseUserAuthorization>(request);
            var result = _mapper.Map<AuthResponse>(response);
            return result;
        }
        public async Task<AuthResponse> LoginUserAsync(UserModel user)
        {
            var request = _mapper.Map<RequestLoginUser>(user);
            var response = await _bus.RequestQuery<RequestLoginUser, ResponseUserAuthorization>(request);
            var result = _mapper.Map<AuthResponse>(response);
            return result;
        }
        public async Task<AuthResponse> RefreshAccessTokenAsync(string refreshToken)
        {
            var response = await _bus.RequestQuery<RequestTokenRefresh, ResponseUserAuthorization>(
                new RequestTokenRefresh()
                {
                    RefreshToken = refreshToken
                });
            var result = _mapper.Map<AuthResponse>(response);
            return result;
        }
        public async Task<ValidationResponse> ValidateAccessTokenAsync(string accessToken)
        {
            var response = await _bus.RequestQuery<RequestTokenValidationCheck, ResponseTokenValidationCheck>(
                new RequestTokenValidationCheck()
                {
                    TokenToValidate = accessToken
                });
            var result = _mapper.Map<ValidationResponse>(response);
            return result;
        }
    }
}
