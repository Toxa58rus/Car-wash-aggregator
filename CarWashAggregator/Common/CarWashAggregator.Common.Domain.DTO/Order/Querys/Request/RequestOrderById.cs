using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestOrderById : Query
    {
        public Guid Id;
    }
}
