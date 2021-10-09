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

        public Task Handle(OrdersQuery query, string replyTo, string correlationId, ulong deliveryTag)
        {
            //some_logic
            _bus.ReplyToQuery(query, replyTo, correlationId, deliveryTag);
            return Task.FromResult(true);
        }
    }
}
