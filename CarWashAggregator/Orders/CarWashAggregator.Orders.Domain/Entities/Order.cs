using System;

namespace CarWashAggregator.Orders.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
        public Guid СarWashId { get; set; }

        public Status СarWashStatus { get; set; }

    }
}
