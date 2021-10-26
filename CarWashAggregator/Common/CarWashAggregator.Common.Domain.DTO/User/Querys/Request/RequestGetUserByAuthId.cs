using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Request
{
    public class RequestGetUserByAuthId : Query
    {
        public Guid AuthId { get; set; }
    }
}
