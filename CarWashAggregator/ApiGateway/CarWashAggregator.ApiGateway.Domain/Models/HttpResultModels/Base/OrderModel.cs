using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
}
