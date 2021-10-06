using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Querys;
using System.Collections.Generic;

namespace CarWashAggregator.Orders.Business.Bus.Querys
{
    public class OrdersQuery : Query
    {
        public List<OrderQueryDto> Orders { get; set; }
    }
}
