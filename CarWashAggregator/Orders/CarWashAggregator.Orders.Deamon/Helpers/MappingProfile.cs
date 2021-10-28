using System;
using AutoMapper;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.Orders.Domain.Entities;

namespace CarWashAggregator.Orders.Deamon.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForPath(dest => dest.Status,
                    opt => opt.MapFrom(src => src.OrderStatus.Name))
                .ReverseMap()
                .ForPath(dest => dest.OrderStatus.Name,
                    opt => opt.MapFrom(src => src.Status));

            CreateMap<RequestSaveNewOrder, Order>();
        }
    }
}
