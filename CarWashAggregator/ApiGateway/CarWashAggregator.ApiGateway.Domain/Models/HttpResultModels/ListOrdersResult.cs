using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
  public  class ListOrdersResult
    {
        public List<OrderModel> Orders { get; set; }
    }
}
