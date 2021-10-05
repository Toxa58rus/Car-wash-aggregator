using CarWashAggregator.Orders.Business.Interfaces;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarWashAggregator.Orders.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _dbRepository;

        public OrderService(IOrderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbRepository.Get<Order>().AsEnumerable();
        }

    }
}
