using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request
{
    public class RequestGetReviewById : Query
    {
        public Guid Id { get; set; }
    }
}
