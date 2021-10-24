using AutoMapper;
using CarWashAggregator.ApiGateway.Domain.Models;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestsModels;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;

namespace CarWashAggregator.ApiGateway.Deamon.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ResponseUserAuthorization, AuthResponse>().ReverseMap();
            CreateMap<ResponseTokenValidationCheck, ValidationResponse>().ReverseMap();
            CreateMap<UserModel, RequestRegisterNewUser>()
                .ForMember(dest => dest.UserRole,
                    opt => opt.MapFrom(src => int.Parse(src.Role)))
                .ReverseMap().ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => src.UserRole.ToString()));
            CreateMap<UserModel, RequestLoginUser>().ReverseMap();
            CreateMap<RegisteredUserModel, UserModel>().ReverseMap();
        }
    }
}
