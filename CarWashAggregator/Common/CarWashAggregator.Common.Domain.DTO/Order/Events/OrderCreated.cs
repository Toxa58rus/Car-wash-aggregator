using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Order.Events
{
    public class OrderCreated : Event
    {
        public Guid UserId { get; set; }
        public Guid СarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
    }
}
