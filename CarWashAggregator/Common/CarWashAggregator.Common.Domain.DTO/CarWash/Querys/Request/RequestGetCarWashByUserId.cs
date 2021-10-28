using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestGetCarWashByUserId : Query
    {
        public Guid UserId { get; set; }
    }
}
