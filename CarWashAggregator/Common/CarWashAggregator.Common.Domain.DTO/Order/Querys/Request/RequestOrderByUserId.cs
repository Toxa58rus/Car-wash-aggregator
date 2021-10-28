using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestOrderByUserId : Query
    {
        public Guid UserId { get; set; }
        public string Status { get; set; }
    }
}
