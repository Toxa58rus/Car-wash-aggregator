using System;
using System.Collections.Generic;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarWashAggregator.Common.Domain.DTO.Order.Querys;

namespace CarWashAggregator.Orders.Business.Handlers.QueryHandlers
{
    public class RequestOrderByCarWashIdHandler : IQueryHandler<RequestOrderByCarWashId, ResponseOrders>
    {
        private readonly IOrderRepository _dbRepository;
        private readonly IMapper _mapper;

        public RequestOrderByCarWashIdHandler(IOrderRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public Task<ResponseOrders> Handle(RequestOrderByCarWashId request)
        {
            var orders = _dbRepository.Get<Order>().Where(o => o.CarWashId == request.CarWashId);
            if (request.FilterDate != null)
               orders = orders.Where(o => o.DateReservation.Date == ((DateTime) request.FilterDate).Date);
            
            return Task.FromResult(new ResponseOrders(){Orders = _mapper.Map<List<OrderDTO>>(orders.ToList())});
        }
    }
}
