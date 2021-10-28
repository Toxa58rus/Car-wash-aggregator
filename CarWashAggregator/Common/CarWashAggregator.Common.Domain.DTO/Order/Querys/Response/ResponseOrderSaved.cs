using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Response
{
    public class ResponseOrderSaved : Query
    {
        public bool Success { set; get; }
    }
}
