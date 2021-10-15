using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.CarWashes.Deamon.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly ICarWashService _carWashService;
        private readonly IEventBus _eventBus;

        public TestController(ICarWashService carWashService, IEventBus eventBus)
        {
            _carWashService = carWashService;
            _eventBus = eventBus;
        }

        public async Task<JsonResult> GetCarWashesAsync()
        {
            return Json(await _carWashService.GetCarWashesAsync());
        }

        public async Task<string> CreateCarWash()
        {
            CarWash carWash = new CarWash();
            await _carWashService.CreateCarWashAsync(carWash);
            return carWash.Id.ToString();
        }

        public async Task<JsonResult> RequestGetCarWashQuery()
        {
            ResponseGetCarWashQuery carWashQuery = await _eventBus.RequestQuery<RequestGetCarWashQuery, ResponseGetCarWashQuery>(new RequestGetCarWashQuery() { Id = new Guid("eb095127-0c41-48a1-be94-5013d38181df") });
            return Json(carWashQuery);
        }

        public async Task<JsonResult> RequestCreateCarWashQuery()
        {
            ResponseCreateCarWashQuery responseCreateCarWashQuery = await _eventBus.RequestQuery<RequestCreateCarWashQuery, ResponseCreateCarWashQuery>(new RequestCreateCarWashQuery()
            {
                UserId = new Guid(),
                Name = "Автомойка",
                Price = 999.99,
                Image = "",
                Description = "Самая крутая автомойка",
                Address = "Твои мечты",
                CarCategories = new string[] { "Седан" }
            }); ;
            return Json(responseCreateCarWashQuery);
        }

        public async Task PublishDeleteCarWashEvent()
        {
            _eventBus.PublishEvent(new DeleteCarWashEvent()
            {
                Id = (await _carWashService.GetCarWashesAsync()).LastOrDefault().Id
            });
        }

        public async Task PublishUpdateCarWashEvent()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CarWash, UpdateCarWashEvent>()));

            CarWash carWash = (await _carWashService.GetCarWashesAsync()).LastOrDefault();
            carWash.Price += 1;

            _eventBus.PublishEvent(mapper.Map<UpdateCarWashEvent>(carWash));
        }

        public async Task PublishUpdateCarWashRatingEvent()
        {
            CarWash carWash = (await _carWashService.GetCarWashesAsync()).Last();
            _eventBus.PublishEvent(new UpdateCarWashRatingEvent()
            {
                CarWashId = carWash.Id,
                AVG_Rating = carWash.AVG_Rating + 1
            });
        }

        public async Task<JsonResult> RequestGetCarWashesPaginatedQuery(int pageSize, int page)
        {
            RequestGetCarWashesPaginatedQuery request = new RequestGetCarWashesPaginatedQuery()
            {
                PageSize = pageSize,
                PageNumber = page
            };
            return Json(await _eventBus.RequestQuery<RequestGetCarWashesPaginatedQuery, ResponseGetCarWashesPaginatedQuery>(request));
        }
    }
}
