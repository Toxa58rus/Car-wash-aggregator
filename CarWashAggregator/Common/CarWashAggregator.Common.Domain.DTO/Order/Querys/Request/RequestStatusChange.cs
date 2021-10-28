using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
   public class RequestStatusChange : Query
    {
        public string NewStatus { get; set; }
        public Guid OrderId { get; set; }
    }
}
