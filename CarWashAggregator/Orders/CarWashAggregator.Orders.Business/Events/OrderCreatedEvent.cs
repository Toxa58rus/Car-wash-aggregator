using CarWashAggregator.Orders.Domain.Contracts;
using System;


namespace CarWashAggregator.Orders.Orders.Events
{
    public class OrderCreatedEvent : Event
    {
        public Guid UserId { get; set; }
        public Guid СarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
    }
}
