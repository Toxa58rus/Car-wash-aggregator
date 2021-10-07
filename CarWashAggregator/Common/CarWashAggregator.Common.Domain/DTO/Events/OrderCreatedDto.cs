using System;

namespace CarWashAggregator.Common.Domain.DTO.Events
{
    public class OrderCreatedDto
    {
        public Guid UserId { get; set; }
        public Guid СarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
    }
}
