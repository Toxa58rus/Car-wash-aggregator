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
    public class GetCarWashQueryHandler : IQueryHandler<RequestGetCarWashById, ResponseGetCarWashById>
    {
        private readonly ICarWashService _carWashService;

        public GetCarWashQueryHandler(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }
        public async Task<ResponseGetCarWashById> Handle(RequestGetCarWashById request)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CarWash, ResponseGetCarWashById>()));

            CarWash carWash = await _carWashService.GetCarWashAsync(request.Id);
            ResponseGetCarWashById carWashQuery = mapper.Map<ResponseGetCarWashById>(carWash);

            return await Task.FromResult(carWashQuery);
        }
    }
}
