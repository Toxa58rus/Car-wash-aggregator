using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request
{
    public class RequestGetReviewByUserId : Query
    {
        public Guid UserId { get; set; }
    }
}
