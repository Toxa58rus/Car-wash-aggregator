using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Events
{
    public class DeleteCarWashEvent : Event
    {
        public Guid Id { get; set; }
    }
}
