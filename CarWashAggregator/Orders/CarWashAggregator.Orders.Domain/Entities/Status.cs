using System;
using System.Collections.Generic;

namespace CarWashAggregator.Orders.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
