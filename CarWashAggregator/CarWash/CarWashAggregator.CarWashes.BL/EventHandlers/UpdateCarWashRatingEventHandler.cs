using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.EventHandlers
{
    public class UpdateCarWashRatingEventHandler : IEventHandler<UpdateCarWashRatingEvent>
    {
        private readonly ICarWashService _carWashService;

        public UpdateCarWashRatingEventHandler(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }

        public async Task Handle(UpdateCarWashRatingEvent @event)
        {
            await _carWashService.UpdateCarWashRatingAsync(@event.CarWashId, @event.AVG_Rating);
        }
    }
}
