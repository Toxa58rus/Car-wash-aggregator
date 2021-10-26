using AutoMapper;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Events;
using CarWashAggregator.User.Domain.Enities;
using CarWashAggregator.User.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.User.Business.EventHandlers
{
    public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserRegisteredEventHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task Handle(UserRegisteredEvent @event)
        {
            await _userService.CreateUserAsync(_mapper.Map<UserInfo>(@event));
        }
    }
}
