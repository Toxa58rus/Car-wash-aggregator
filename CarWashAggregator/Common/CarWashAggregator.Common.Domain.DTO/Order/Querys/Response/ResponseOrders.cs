using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Response
{
    public class ResponseOrders : Query
    {
        public List<OrderDTO> Orders { get; set; }
    }
}
