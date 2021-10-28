using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.CarWashes.BL.AutoMapperProfiles
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarWash, CarWashDTO>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.AVG_Rating.ToString()))
                .ForMember(dest => dest.Img, opt => opt.MapFrom(src => src.Image));

            CreateMap<RequestCreateCarWashQuery, CarWash>();
        }
    }
}
