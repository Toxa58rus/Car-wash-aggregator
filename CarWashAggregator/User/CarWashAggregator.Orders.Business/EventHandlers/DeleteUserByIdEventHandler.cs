using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Events;
using CarWashAggregator.Orders.Business.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.EventHandlers
{
    public class DeleteUserByIdEventHandler : IEventHandler<DeleteUserByIdEvent>
    {
        private readonly IUserService _userService;

        public DeleteUserByIdEventHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(DeleteUserByIdEvent @event)
        {
            await _userService.DeleteUserByIdAsync(@event.Id);
        }
    }
}
