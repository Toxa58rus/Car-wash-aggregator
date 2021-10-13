using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestSaveNewOrder : Query
    {
        public Guid UserId { get; set; }
        public Guid СarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
