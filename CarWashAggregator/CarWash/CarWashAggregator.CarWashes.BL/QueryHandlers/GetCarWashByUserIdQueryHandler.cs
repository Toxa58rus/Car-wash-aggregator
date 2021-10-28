using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
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
    public class GetCarWashByUserIdQueryHandler : IQueryHandler<RequestGetCarWashByUserId, ResponseGetCarWashByUserId>
    {
        private readonly ICarWashService _carWashService;
        private readonly IMapper _mapper;

        public GetCarWashByUserIdQueryHandler(ICarWashService carWashService, IMapper mapper)
        {
            _carWashService = carWashService;
            _mapper = mapper;
        }

        public async Task<ResponseGetCarWashByUserId> Handle(RequestGetCarWashByUserId request)
        {
            var carWashes = (await _carWashService.GetCarWashesAsync()).Where(x => x.UserId == request.UserId);
            return new ResponseGetCarWashByUserId() { CarWashes = _mapper.Map<List<CarWashDTO>>(carWashes) };
        }
    }
}
