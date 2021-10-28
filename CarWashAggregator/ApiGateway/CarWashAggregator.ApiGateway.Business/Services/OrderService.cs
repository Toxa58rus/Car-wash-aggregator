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
    public class OrderService : IOrderService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IMapper mapper, IEventBus bus, ILogger<OrderService> logger)
        {
            _mapper = mapper;
            _bus = bus;
            _logger = logger;
        }

        public async Task<OrderModel> GetById(Guid id)
        {
            var result =
                await _bus.RequestQuery<RequestOrderById, ResponseOrder>(new RequestOrderById()
                { Id = id });

            return _mapper.Map<OrderModel>(result.Order);
        }

        public async Task<List<OrderModel>> GetByUserId(Guid userId)
        {
            var result =
                await _bus.RequestQuery<RequestOrderByUserId, ResponseOrders>(new RequestOrderByUserId
                {
                    UserId = userId
                });

            return _mapper.Map<List<OrderModel>>(result.Orders);
        }
        public async Task<List<OrderModel>> GetByCarWashId(Guid carWashId, DateTime? filterDate = null)
        {
            var result =
                await _bus.RequestQuery<RequestOrderByCarWashId, ResponseOrders>(new RequestOrderByCarWashId
                {
                    CarWashId = carWashId,
                    FilterDate = filterDate
                });

            return _mapper.Map<List<OrderModel>>(result.Orders);
        }
        public async Task<string[]> GetOrderStatuses()
        {
            var result =
                await _bus.RequestQuery<RequestStatuses, ResponseStatuses>(new RequestStatuses());

            return result.Statuses;
        }
        public async Task<bool> ChangeStatus(string newStatus, Guid orderId)
        {
            var result =
                await _bus.RequestQuery<RequestStatusChange, ResponseStatusChange>(new RequestStatusChange
                {
                    NewStatus = newStatus,
                    OrderId = orderId
                });

            return result.Success;
        }
        public async Task<bool> AddOrder(OrderAdd order)
        {
            RequestSaveNewOrder request;
            try
            {
                request = _mapper.Map<RequestSaveNewOrder>(order);
            }
            catch
            {
                _logger.LogError("cannot map OrderModel to RequestSaveOrder");
                throw;
            }

            var result =
                await _bus.RequestQuery<RequestSaveNewOrder, ResponseOrderSaved>(request);
            return result?.OrderId != null;
        }
    }
}
