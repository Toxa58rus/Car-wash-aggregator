using CarWashAggregator.Common.Domain.Contracts;
using System.Collections.Generic;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response
{
    public class ResponseGetReview : Query
    {
        public ReviewDto Review { get; set; }
    }
}
