using CarWashAggregator.Orders.Domain.Models;
using System.Collections.Generic;

namespace CarWashAggregator.Orders.Business.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
    }
}
