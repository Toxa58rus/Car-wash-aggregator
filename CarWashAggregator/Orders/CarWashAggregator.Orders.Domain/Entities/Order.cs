using System;

namespace CarWashAggregator.Orders.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
        public Guid CarWashId { get; set; }
        public string CarCategory { get; set; }

        public Guid StatusId { get; set; }
        public Status OrderStatus { get; set; }

    }
}
