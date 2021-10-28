using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.Handlers.QueryHandlers
{
    public class RequestStatusChangeHandler : IQueryHandler<RequestStatusChange, ResponseStatusChange>
    {
        private readonly IOrderRepository _dbRepository;

        public RequestStatusChangeHandler(IOrderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<ResponseStatusChange> Handle(RequestStatusChange request)
        {
            var order = _dbRepository.Get<Order>().SingleOrDefault(o => o.Id == request.OrderId);
            if (order is null)
                return new ResponseStatusChange();

            order.OrderStatus.Name = request.NewStatus;
            await _dbRepository.Update(order);
            await _dbRepository.SaveChangesAsync();
            return new ResponseStatusChange(){Success = true};
        }
    }
}
