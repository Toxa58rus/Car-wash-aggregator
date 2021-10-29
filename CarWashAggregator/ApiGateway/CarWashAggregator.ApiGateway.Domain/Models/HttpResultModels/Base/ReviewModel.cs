using System;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid carWashId { get; set; }
        public  string Message { get; set; }
        public double Rating { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
