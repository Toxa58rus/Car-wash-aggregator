using CarWashAggregator.Orders.Business.Interfaces;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarWashAggregator.Orders.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbRepository _dbRepository;

        public OrderService(IDbRepository accountRepository)
        {
            _dbRepository = accountRepository;
        }

        public IEnumerable<Order> GetAccounts()
        {
            return _dbRepository.Get<Order>().AsEnumerable();
        }

    }
}
