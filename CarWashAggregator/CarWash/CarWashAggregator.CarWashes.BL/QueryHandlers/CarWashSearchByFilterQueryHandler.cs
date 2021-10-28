using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.QueryHandlers
{
    public class CarWashSearchByFilterQueryHandler : IQueryHandler<RequestCarWashByFilters, ResponseCarWashSearchByFilters>
    {
        private readonly ICarWashService _carWashService;
        private readonly IMapper _mapper;

        public CarWashSearchByFilterQueryHandler(ICarWashService carWashService, IMapper mapper)
        {
            _carWashService = carWashService;
            _mapper = mapper;
        }

        public async Task<ResponseCarWashSearchByFilters> Handle(RequestCarWashByFilters request)
        {
            var carWashes = await _carWashService.GetCarWashesAsync();

            if (request.CarCategory != string.Empty && request.CarCategory != null)
                carWashes = carWashes.Where(x => x.CarCategories.Contains(request.CarCategory));

            if (request.CityId != Guid.Empty && request.CityId != null)
                carWashes = carWashes.Where(x => x.CityId == request.CityId);

            if (request.CarWashName != String.Empty && request.CarWashName != null)
                carWashes = carWashes.Where(x => x.Name == request.CarWashName);

            return new ResponseCarWashSearchByFilters() { Washes = _mapper.Map<List<CarWashDTO>>(carWashes) };
        }
    }
}
