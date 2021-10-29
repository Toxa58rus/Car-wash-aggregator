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
using Microsoft.EntityFrameworkCore;

namespace CarWashAggregator.Orders.Business.Handlers.QueryHandlers
{
    public class RequestOrderByUserIdHandler : IQueryHandler<RequestOrderByUserId, ResponseOrders>
    {
        private readonly IOrderRepository _dbRepository;
        private readonly IMapper _mapper;

        public RequestOrderByUserIdHandler(IOrderRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public Task<ResponseOrders> Handle(RequestOrderByUserId request)
        {
            var orders = _dbRepository.Get<Order>().Where(o => o.UserId == request.UserId).Include(o=>o.OrderStatus);
            if (!string.IsNullOrWhiteSpace(request.Status))
                orders = orders.Where(o => o.OrderStatus.Name == request.Status).Include(o => o.OrderStatus);

            return Task.FromResult(new ResponseOrders() { Orders = _mapper.Map<List<OrderDTO>>(orders.ToList()) });
        }
    }
}
