using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using System;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IEventBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<AuthenticatedUserModel> GetUserByAuthId(Guid id)
        {
            var response =
                await _bus.RequestQuery<RequestGetUserByAuthId, ResponseGetUser>(new RequestGetUserByAuthId { AuthId = id });

            var result = response is null ? new AuthenticatedUserModel() : _mapper.Map<AuthenticatedUserModel>(response);
            return result;
        }
    }
}
