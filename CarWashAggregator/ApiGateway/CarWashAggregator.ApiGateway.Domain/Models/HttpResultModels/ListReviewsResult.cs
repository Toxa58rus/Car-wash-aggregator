using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
  public  class ListReviewsResult
    {
        public List<ReviewModel> Reviews { get; set; }
    }
}
