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
    public class RequestOrderByReservationTimeHandler : IQueryHandler<RequestOrderByReservationTime, ResponseOrders>
    {
        private readonly IOrderRepository _dbRepository;
        private readonly IMapper _mapper;

        public RequestOrderByReservationTimeHandler(IOrderRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public Task<ResponseOrders> Handle(RequestOrderByReservationTime request)
        {
            var orders = _dbRepository.Get<Order>().Where(o => o.DateReservation.Date == request.ReservationDate.Date);
            if (request.ReservationTime != null)
               orders = orders.Where(o =>
                    o.DateReservation.TimeOfDay == ((DateTime) request.ReservationTime).TimeOfDay);

            return Task.FromResult(new ResponseOrders(){Orders = _mapper.Map<List<OrderDTO>>(orders.ToList())});
        }
    }
}
