using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarWashId { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Price { get; set; }
        public  string CarCategory { get; set; }
        public string Status { get; set; }
    }
}
