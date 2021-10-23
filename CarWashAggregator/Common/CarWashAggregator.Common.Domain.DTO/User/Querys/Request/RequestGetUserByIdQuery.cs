using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Request
{
    public class RequestGetUserByIdQuery : Query
    {
        public Guid Id { get; set; }
    }
}
