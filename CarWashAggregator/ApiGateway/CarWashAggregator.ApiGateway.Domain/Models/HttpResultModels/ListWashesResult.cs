using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
  public  class ListWashesResult
    {
        public List<CarWashModel> CarWashes { get; set; }
    }
}
