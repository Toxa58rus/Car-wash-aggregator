using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Request
{
    public class RequestGetUserByUserId : Query
    {
        public Guid UserId { get; set; }
    }
}
