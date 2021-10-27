using AutoMapper;
using CarWashAggregator.Common.Domain.DTO.User.Events;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.User.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Business.AutoMapperProfiles
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserInfo, UserRegisteredEvent>();
            CreateMap<UserInfo, ResponseGetUser>();
            CreateMap<UserRegisteredEvent, UserInfo>();
        }
    }
}
