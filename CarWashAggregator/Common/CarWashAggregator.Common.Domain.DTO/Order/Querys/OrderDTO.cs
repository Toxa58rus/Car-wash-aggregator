using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
        public string CarCategory { get; set; }
        public string Status { get; set; }

    }
}
