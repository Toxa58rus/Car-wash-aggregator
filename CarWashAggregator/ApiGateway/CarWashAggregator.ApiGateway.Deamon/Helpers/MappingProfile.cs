using System;
using AutoMapper;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;
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
using Microsoft.AspNetCore.Routing.Constraints;

namespace CarWashAggregator.ApiGateway.Deamon.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //AuthService
            CreateMap<ResponseUserAuthorization, AuthResponse>().ReverseMap();
            CreateMap<ResponseTokenValidationCheck, ValidationResponse>().ReverseMap();
            CreateMap<UserModel, RequestRegisterNewUser>()
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => int.Parse(src.Role)))
                .ReverseMap().ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => src.Role.ToString()));
            CreateMap<AuthenticatedUserModel, ResponseGetUser>()
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => int.Parse(src.Role)))
                .ReverseMap().ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => src.Role.ToString()));
            CreateMap<UserModel, RequestLoginUser>().ReverseMap();
           
            //UserService
            CreateMap<AuthenticatedUserModel, UserModel>().ReverseMap();
            CreateMap<UserProfile, RequestChangeUserProfile>()
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => new Guid(src.UserId)));

            //CarWashService
            CreateMap<CarWashDTO, CarWashModel>().ReverseMap();
            CreateMap<CarWashSearch, RequestCarWashByFilters>().ReverseMap();
            CreateMap<CarWashAdd, RequestCreateCarWashQuery>()
                .ForMember(dest => dest.CityId,
                    opt => opt.MapFrom(src => new Guid(src.CityId)))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => new Guid(src.PartnerId)))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => double.Parse(src.Price)));

            //OrderService
            CreateMap<OrderModel, OrderDTO>().ReverseMap();
            CreateMap<OrderAdd, RequestSaveNewOrder>()
                .ForMember(dest => dest.DateReservation,
                    opt => opt.MapFrom(src => DateTime.Parse(src.DateReservation)))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => decimal.Parse(src.Price)))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => new Guid(src.UserId)))
                .ForMember(dest => dest.CarWashId,
                    opt => opt.MapFrom(src => new Guid(src.СarWashId)));

            //ReviewService
            CreateMap<ReviewModel, ReviewDto>().ReverseMap();
            CreateMap<ReviewAdd,RequestCreateReviewDtoQuery>()
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => new Guid(src.UserId)))
                .ForMember(dest => dest.CarWashId,
                    opt => opt.MapFrom(src => new Guid(src.СarWashId)));
        }
    }
}
