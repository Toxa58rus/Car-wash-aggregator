using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Events
{
    public class UpdateCarWashRatingEvent : Event
    {
        public Guid CarWashId { get; set; }
        public double AVG_Rating { get; set; }
    }
}
