using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class CarWashService : ICarWashService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;
        private readonly ILogger<CarWashService> _logger;

        public CarWashService(IMapper mapper, IEventBus bus, ILogger<CarWashService> logger)
        {
            _mapper = mapper;
            _bus = bus;
            _logger = logger;
        }

        public async Task<List<CarWashModel>> SearchAsync(CarWashSearch query)
        {
            var requestOrders = new RequestOrderByReservationTme();
            if (!string.IsNullOrWhiteSpace(query.Date))
            {
                try
                {
                    requestOrders.ReservationDate = DateTime.Parse(query.Date);
                }
                catch 
                {
                    _logger.LogWarning("Cant Parse Date");
                    throw;
                }

                if (!string.IsNullOrWhiteSpace(query.Time))
                {
                    try
                    {
                        requestOrders.ReservationTime = int.Parse(query.Time);
                    }
                    catch
                    {
                        _logger.LogWarning("Cant Parse Time");
                        throw;
                    }
                }
            }
            var responseOrders = await _bus.RequestQuery<RequestOrderByReservationTme, ResponseOrders>(requestOrders);

            var requestCarWashes = _mapper.Map<RequestCarWashByFilters>(query); 
            var responseCarWashes = await _bus.RequestQuery<RequestCarWashByFilters, ResponseCarWashSearchByFilters>(requestCarWashes);

            try
            {
                //TODO Check performance
                var result = responseCarWashes.Washes.ToDictionary(x => x.Id);
                foreach (var order in responseOrders.Orders)
                {
                    result.Remove(order.CarWashId);
                }
                return _mapper.Map<List<CarWashModel>>(result.Values.ToList());
            }
            catch
            {
                _logger.LogError("Error in carWashService");
                throw;
            }
        }

        public async Task<CarWashModel> GetById(Guid id)
        {
            var result =
                await _bus.RequestQuery<RequestGetCarWashById, ResponseGetCarWashById>(new RequestGetCarWashById
                    {Id = id});

            return _mapper.Map<CarWashModel>(result.Wash);
        }
        
        public async Task<List<CarWashModel>> GetByUserId(Guid userId)
        {
            var result =
                await _bus.RequestQuery<RequestGetCarWashByUserId, ResponseGetCarWashByUserId>(new RequestGetCarWashByUserId
                { UserId = userId });

            return _mapper.Map<List<CarWashModel>>(result.CarWashes);
        }
        public async Task<bool> AddCarWash(CarWashAdd carWash)
        {
            var request = _mapper.Map<RequestCreateCarWashQuery>(carWash);
            var result =
                await _bus.RequestQuery<RequestCreateCarWashQuery, ResponseCreateCarWashQuery>(request);
            return result?.Id != null;
        }
    }
}
