using AutoMapper;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;

namespace CarWashAggregator.ApiGateway.Deamon.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
            CreateMap<AuthenticatedUserModel, UserModel>().ReverseMap();
            CreateMap<CarWashDTO, CarWashModel>().ReverseMap();
            CreateMap<CarWashSearch, RequestCarWashByFilters>();
        }
    }
}
