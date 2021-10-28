using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
   public class ReviewAdd
    {
        public string UserId { get; set; }
        public string СarWashId { get; set; }
        public string Message { get; set; }
        public string Rating { get; set; }
    }
}
