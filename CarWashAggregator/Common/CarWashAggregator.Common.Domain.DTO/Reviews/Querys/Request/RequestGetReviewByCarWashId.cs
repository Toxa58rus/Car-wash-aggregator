using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request
{
    public class RequestGetReviewByCarWashId : Query
    {
        public Guid CarWashId { get; set; }
    }
}
