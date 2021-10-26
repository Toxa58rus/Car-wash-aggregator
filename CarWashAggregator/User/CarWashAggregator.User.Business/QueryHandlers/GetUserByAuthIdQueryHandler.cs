using AutoMapper;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.User.Domain.Enities;
using CarWashAggregator.User.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.User.Business.QueryHandlers
{
    public class GetUserByAuthIdQueryHandler : IQueryHandler<RequestGetUserByAuthId, ResponseGetUser>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByAuthIdQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ResponseGetUser> Handle(RequestGetUserByAuthId request)
        {
            UserInfo user = await _userService.GetUserByAuthIdAsync(request.AuthId);
            return _mapper.Map<ResponseGetUser>(user);
        }
    }
}
