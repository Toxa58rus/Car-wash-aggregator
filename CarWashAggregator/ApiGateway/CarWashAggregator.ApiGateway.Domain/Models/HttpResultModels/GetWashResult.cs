using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
    public class GetWashResult
    {
        public CarWashModel Wash { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
