using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Response
{
    public class ResponseOrder : Query
    {
        public OrderDTO Order { get; set; }
    }
}
