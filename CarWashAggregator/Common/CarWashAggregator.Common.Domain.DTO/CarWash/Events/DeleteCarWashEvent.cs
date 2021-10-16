using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Events
{
    public class DeleteCarWashEvent : Event
    {
        public Guid Id { get; set; }
    }
}
