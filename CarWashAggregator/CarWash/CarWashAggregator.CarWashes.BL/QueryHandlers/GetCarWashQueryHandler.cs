using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys;
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
        private readonly IMapper _mapper;

        public GetCarWashQueryHandler(ICarWashService carWashService, IMapper mapper)
        {
            _carWashService = carWashService;
            _mapper = mapper;
        }
        public async Task<ResponseGetCarWashById> Handle(RequestGetCarWashById request)
        {
            CarWash carWash = await _carWashService.GetCarWashAsync(request.Id);
            ResponseGetCarWashById carWashQuery =new ResponseGetCarWashById() { Wash = _mapper.Map<CarWashDTO>(carWash) };

            return await Task.FromResult(carWashQuery);
        }
    }
}
