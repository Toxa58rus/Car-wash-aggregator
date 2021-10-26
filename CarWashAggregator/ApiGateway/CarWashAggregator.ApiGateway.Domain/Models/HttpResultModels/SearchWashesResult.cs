using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
  public  class SearchWashesResult
    {
        public List<CarWashModel> Washes { get; set; }
    }
}
