using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.Handlers.QueryHandlers
{
    public class RequestByIdHandler : IQueryHandler<RequestOrderById, ResponseOneOrder>
    {
        private readonly IOrderRepository _dbRepository;

        public RequestByIdHandler(IOrderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public Task<ResponseOneOrder> Handle(RequestOrderById request)
        {
            //some_logic
            var order = _dbRepository.Get<Order>().SingleOrDefault(o => o.Id == request.Id);
            if (order is null)
                return Task.FromResult(new ResponseOneOrder());

            var response = new ResponseOneOrder() { Price = order.Price };
            return Task.FromResult(response);
        }
    }
}
