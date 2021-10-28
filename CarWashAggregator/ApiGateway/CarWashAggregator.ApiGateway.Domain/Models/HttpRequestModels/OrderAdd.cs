using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
   public class OrderAdd
    {
        public string UserId { get; set; }
        public string СarWashId { get; set; }
        public string DateReservation { get; set; }
        public string Price { get; set; }
        public string CarCategory { get; set; }
        public string Status { get; set; }
    }
}
