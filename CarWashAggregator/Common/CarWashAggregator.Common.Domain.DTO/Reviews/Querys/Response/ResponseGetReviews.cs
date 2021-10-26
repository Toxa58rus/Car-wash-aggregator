using CarWashAggregator.Common.Domain.Contracts;
using System.Collections.Generic;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response
{
    public class ResponseGetReviews : Query
    {
        public List<ReviewDto> Reviews { get; set; }
    }
}
