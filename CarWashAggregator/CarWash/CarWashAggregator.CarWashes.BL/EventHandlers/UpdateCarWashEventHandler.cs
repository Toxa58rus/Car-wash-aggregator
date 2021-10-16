using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.EventHandlers
{
    public class UpdateCarWashEventHandler : IEventHandler<UpdateCarWashEvent>
    {
        private readonly ICarWashService _carWashService;

        public UpdateCarWashEventHandler(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }
        public async Task Handle(UpdateCarWashEvent @event)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UpdateCarWashEvent, CarWash>()));
            CarWash carWash = mapper.Map<CarWash>(@event);

            await _carWashService.UpdateCarWashAsync(carWash);
        }
    }
}
