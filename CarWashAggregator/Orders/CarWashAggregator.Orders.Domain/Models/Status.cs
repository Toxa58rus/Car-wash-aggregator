using System;

namespace CarWashAggregator.Orders.Domain.Models
{
    public class Status
    {
        public string Name { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
