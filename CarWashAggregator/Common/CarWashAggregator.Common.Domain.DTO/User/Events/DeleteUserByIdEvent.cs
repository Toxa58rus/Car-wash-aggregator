using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.User.Events
{
    public class DeleteUserByIdEvent : Event
    {
        public Guid Id { get; set; }
    }
}
