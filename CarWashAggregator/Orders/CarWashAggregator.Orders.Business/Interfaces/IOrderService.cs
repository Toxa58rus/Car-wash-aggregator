using CarWashAggregator.Orders.Domain.Entities;
using System.Collections.Generic;

namespace CarWashAggregator.Orders.Business.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
    }
}
