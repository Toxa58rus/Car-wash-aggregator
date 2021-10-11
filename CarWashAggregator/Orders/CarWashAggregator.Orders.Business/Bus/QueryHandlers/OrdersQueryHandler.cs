using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Orders.Business.Bus.Querys;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.Bus.QueryHandlers
{
    public class OrdersQueryHandler : IQueryHandler<OrdersQuery>
    {
        public Task<OrdersQuery> Handle(OrdersQuery query)
        {
            //some_logic
            return Task.FromResult(query);
        }
    }
}
