using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.EventHandlers
{
    public class DeleteCarWashEventHandler : IEventHandler<DeleteCarWashEvent>
    {
        private readonly ICarWashService _carWashService;

        public DeleteCarWashEventHandler(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }
        public async Task Handle(DeleteCarWashEvent @event)
        {
            await _carWashService.DeleteCarWashByIdAsync(@event.Id);
        }
    }
}
