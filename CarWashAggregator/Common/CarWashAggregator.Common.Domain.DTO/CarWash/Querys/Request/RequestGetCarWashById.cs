using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestGetCarWashById : Query
    {
        public Guid Id { get; set; }
    }
}
