using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.User.Events
{
    public class DeleteUserByIdEvent : Event
    {
        public Guid Id { get; set; }
    }
}
