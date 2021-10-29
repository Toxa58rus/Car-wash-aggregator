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
            var carWash = (await _carWashService.GetCarWashesAsync()).Last();
            ResponseGetCarWashById carWashQuery = await _eventBus.RequestQuery<RequestGetCarWashById, ResponseGetCarWashById>(new RequestGetCarWashById() { Id = carWash.Id});
            return Json(carWashQuery);
        }

        public async Task<JsonResult> RequestCreateCarWashQuery()
        {
            ResponseCreateCarWashQuery responseCreateCarWashQuery = await _eventBus.RequestQuery<RequestCreateCarWashQuery, ResponseCreateCarWashQuery>(new RequestCreateCarWashQuery()
            {
                UserId = new Guid(),
                Name = "Автомойка",
                Price = 999.99,
                Image = "Image",
                CityId = new Guid(),
                Description = "самая крутая автомойка",
                Address = "Твои мечты",
                Phone = "123456789",
                CarCategories = new string[] { "A", "B", "C" }
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

        public async Task<JsonResult> RequestGetCarWashByUserIdQuery()
        {
            var carWash = (await _carWashService.GetCarWashesAsync()).Last();
            RequestGetCarWashByUserId request = new RequestGetCarWashByUserId() { UserId = carWash.UserId };
            return Json(await _eventBus.RequestQuery<RequestGetCarWashByUserId, ResponseGetCarWashByUserId>(request));
        }

        public async Task<JsonResult> RequestCarWashSearchByFilterQuery()
        {
            RequestCarWashByFilters request = new RequestCarWashByFilters() { CarCategory = "A", CityId = null, CarWashName = null };
            return Json(await _eventBus.RequestQuery<RequestCarWashByFilters, ResponseCarWashSearchByFilters>(request));
        }
    }
}
