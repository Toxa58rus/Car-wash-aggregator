using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Response
{
   public  class ResponseStatuses :Query
    {
        public string[] Statuses { get; set; }
    }
}
