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
    public class RequestByIdHandler : IQueryHandler<RequestOrderById, ResponseOrder>
    {
        private readonly IOrderRepository _dbRepository;
        private readonly IMapper _mapper;

        public RequestByIdHandler(IOrderRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public Task<ResponseOrder> Handle(RequestOrderById request)
        {
            var order = _dbRepository.Get<Order>().Include(o => o.OrderStatus).SingleOrDefault(o => o.Id == request.Id);
            if (order is null)
                return Task.FromResult(new ResponseOrder());

            return Task.FromResult(new ResponseOrder {Order = _mapper.Map<OrderDTO>(order)});
        }
    }
}
