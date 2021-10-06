using System;

namespace CarWashAggregator.Common.Domain.DTO.Querys
{
    public class OrderQueryDto
    {
        public Guid UserId { get; set; }
        public Guid СarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }

        //add properties
    }
}
