using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.QueryHandlers
{
    public class GetCarWashesPaginatedQueryHandler : IQueryHandler<RequestGetCarWashesPaginatedQuery, ResponseGetCarWashesPaginatedQuery>
    {
        private readonly ICarWashService _carWashService;

        public GetCarWashesPaginatedQueryHandler(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }
        public async Task<ResponseGetCarWashesPaginatedQuery> Handle(RequestGetCarWashesPaginatedQuery request)
        {
            List<CarWash> carWashes = (await _carWashService.GetCarWashesPaginatedAsync(request.PageSize, request.PageNumber)).ToList();

            ResponseGetCarWashesPaginatedQuery response = new ResponseGetCarWashesPaginatedQuery()
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                TotalRecords = await _carWashService.CountCarWashesAsync(),
                Data = carWashes
            };
            response.TotalPages = Convert.ToInt32(Math.Ceiling((double)response.TotalRecords / (double)response.PageSize));

            return response;
        }
    }
}
