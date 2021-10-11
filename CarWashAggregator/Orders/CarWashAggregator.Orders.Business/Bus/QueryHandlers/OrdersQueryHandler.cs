using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Orders.Business.Bus.Querys;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.Bus.QueryHandlers
{

    public class OrdersQueryHandler : IQueryHandler<OrdersQuery>
    {
        private readonly IEventBus _bus;

        public OrdersQueryHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<OrdersQuery> Handle(OrdersQuery query)
        {
            //some_logic
            return Task.FromResult(query);
        }
    }
}
