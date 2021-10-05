using System;

namespace CarWashAggregator.Orders.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
