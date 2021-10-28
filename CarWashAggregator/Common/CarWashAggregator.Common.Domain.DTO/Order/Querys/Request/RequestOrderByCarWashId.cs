using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestOrderByCarWashId:Query
    {
        public Guid CarWashId { get; set; }
        public DateTime? FilterDate { get; set; }
    }
}
