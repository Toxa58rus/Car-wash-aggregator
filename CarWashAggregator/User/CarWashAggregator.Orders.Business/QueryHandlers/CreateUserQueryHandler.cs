using AutoMapper;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.User.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarWashAggregator.User.Domain.interfaces;

namespace CarWashAggregator.Orders.Business.QueryHandlers
{
    public class CreateUserQueryHandler : IQueryHandler<RequestRoleIdByUserIdQuery, ResponseCreateUserQuery>
    {
        private readonly IUserService _userService;

        public CreateUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResponseCreateUserQuery> Handle(RequestRoleIdByUserIdQuery request)
        {
            var mapper = new Mapper(
                new MapperConfiguration(cfg => cfg.CreateMap<RequestRoleIdByUserIdQuery, UserInfo>()
                    .ForMember("Role", opt => opt.Ignore())
            ));
            UserInfo user = mapper.Map<UserInfo>(request);

            Guid id = await _userService.CreateUserAsync(user);

            return new ResponseCreateUserQuery() { Id = id };
        }
    }
}
