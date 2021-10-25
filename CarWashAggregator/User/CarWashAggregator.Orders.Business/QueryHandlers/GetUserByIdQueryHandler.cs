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
    //public class GetUserByIdQueryHandler : IQueryHandler<RequestGetUserByIdQuery, ResponseGetUserByIdQuery>
    //{
    //    private readonly IUserService _userService;

    //    public GetUserByIdQueryHandler(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    public async Task<ResponseGetUserByIdQuery> Handle(RequestGetUserByIdQuery request)
    //    {
    //        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, ResponseGetUserByIdQuery>()));

    //        UserInfo user = await _userService.GetUserByIdAsync(request.Id);
    //        return mapper.Map<ResponseGetUserByIdQuery>(user);
    //    }
    //}
}
