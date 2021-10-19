using CarWashAggregator.Common.Domain.Contracts;
using System.Collections.Generic;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response
{
    public class ResponseGetReviewsBuUserIdDtoQuery : Query
    {
        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}
