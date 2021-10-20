using AutoMapper;
using CarWashAggregator.ApiGateway.Domain.Models;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;

namespace CarWashAggregator.ApiGateway.Deamon.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ResponseUserAuthorization, AuthResponse>().ReverseMap();
            CreateMap<ResponseTokenValidationCheck, ValidationResponse>().ReverseMap();
            CreateMap<UserModel, RequestRegisterNewUser>().ReverseMap();
            CreateMap<UserModel, RequestLoginUser>().ReverseMap();
        }
    }
}
