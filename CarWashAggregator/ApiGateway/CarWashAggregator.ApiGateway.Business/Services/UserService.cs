using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using System;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;
using Microsoft.Extensions.Logging;

namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IMapper mapper, IEventBus bus, ILogger<UserService> logger)
        {
            _mapper = mapper;
            _bus = bus;
            _logger = logger;
        }

        public async Task<AuthenticatedUserModel> GetUserById(Guid id)
        {
            var response =
                await _bus.RequestQuery<RequestGetUserByUserId, ResponseGetUser>(new RequestGetUserByUserId { UserId = id });

            var result = response is null ? new AuthenticatedUserModel() : _mapper.Map<AuthenticatedUserModel>(response);
            return result;
        }
        public async Task<AuthenticatedUserModel> GetUserByAuthId(Guid id)
        {
            var response =
                await _bus.RequestQuery<RequestGetUserByAuthId, ResponseGetUser>(new RequestGetUserByAuthId { AuthId = id });

            var result = response is null ? new AuthenticatedUserModel() : _mapper.Map<AuthenticatedUserModel>(response);
            return result;
        }
        public async Task<bool> ChangeUserProfile(UserProfile profile)
        {
            RequestChangeUserProfile request;
            try
            {
                request = _mapper.Map<RequestChangeUserProfile>(profile);
                
            }
            catch
            {
               _logger.LogError("cannot map user profile");
                throw;
            }
            var result =
                await _bus.RequestQuery<RequestChangeUserProfile, ResponseUserProfileChanged>(request);
            return result?.Success ?? false;
        }
    }
}
