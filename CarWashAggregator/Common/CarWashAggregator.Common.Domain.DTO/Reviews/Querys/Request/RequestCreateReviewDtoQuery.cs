using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request
{
    public class RequestCreateReviewDtoQuery : Query
    {
        public Guid UserId { get; set; }

        public Guid CarWashId { get; set; }

        public string Message { get; set; }

        public double Rating { get; set; }
    }
}
