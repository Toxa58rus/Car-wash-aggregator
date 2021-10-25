using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using System;
using System.Threading.Tasks;

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

        public async Task<AuthenticatedUserModel> GetUserById(Guid id)
        {
            var response =
                await _bus.RequestQuery<RequestGetUserByIdQuery, ResponseGetUserQuery>(new RequestGetUserByIdQuery { Id = id });

            var result = response is null ? null : _mapper.Map<AuthenticatedUserModel>(response);
            return result;
        }
        public async Task<int?> GetUserRoleByUserId(Guid id)
        {
            var response =
                await _bus.RequestQuery<RequestRoleIdByUserIdQuery, ResponseRoleIdByUserIdQuery>(new RequestRoleIdByUserIdQuery { Id = id });
            return response.Role;
        }
    }
}
