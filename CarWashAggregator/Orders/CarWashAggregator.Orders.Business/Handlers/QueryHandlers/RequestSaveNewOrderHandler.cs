using System;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace CarWashAggregator.Orders.Business.Handlers.QueryHandlers
{
    public class RequestSaveNewOrderHandler : IQueryHandler<RequestSaveNewOrder, ResponseOrderSaved>
    {
        private readonly IOrderRepository _dbRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RequestSaveNewOrderHandler> _logger;

        public RequestSaveNewOrderHandler(IOrderRepository dbRepository, IMapper mapper, ILogger<RequestSaveNewOrderHandler> logger)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseOrderSaved> Handle(RequestSaveNewOrder request)
        {
            try
            {
                var status = _dbRepository.Get<Status>().Single(s => s.Name.Equals(request.Status));
                var order = _mapper.Map<Order>(request);
                order.OrderStatus = status;
                await _dbRepository.Add(order);
                await _dbRepository.SaveChangesAsync();

                return new ResponseOrderSaved
                {
                    Success = true
                };
            }
            catch
            {
                _logger.LogError("Cannot create new order");
                return new ResponseOrderSaved();
            }
           
        }
    }
}
