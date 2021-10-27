using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestOrdersByCarWashId
    {
        public Guid CarWashId { get; set; }
    }
}
