using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.QueryHandlers
{
    public class CreateCarWashQueryHandler : IQueryHandler<RequestCreateCarWashQuery, ResponseCreateCarWashQuery>
    {
        private readonly ICarWashService _carWashService;

        public CreateCarWashQueryHandler(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }
        public async Task<ResponseCreateCarWashQuery> Handle(RequestCreateCarWashQuery request)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<RequestCreateCarWashQuery, CarWash>()));
            CarWash carWash = mapper.Map<CarWash>(request);

            Guid id = await _carWashService.CreateCarWashAsync(carWash);

            return new ResponseCreateCarWashQuery() { Id = id };
        }
    }
}
