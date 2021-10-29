using System;

namespace CarWashAggregator.Common.Domain.DTO.Reviews
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarWashId { get; set; }
        public string Message { get; set; }
        public double Rating { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
