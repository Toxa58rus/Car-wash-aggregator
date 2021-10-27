using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CarWashAggregator.User.Domain.Enities;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.User.Events;
using AutoMapper;
using CarWashAggregator.User.Domain.interfaces;

namespace CarWashAggregator.User.Deamon.Controllers
{
    public class ValuesController : Controller
    {
        private readonly IUserService _carUserService;
        private readonly IEventBus _eventBus;

        public ValuesController(IUserService carUserService, IEventBus eventBus)
        {
            _carUserService = carUserService;
            _eventBus = eventBus;
        }
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_carUserService.GetUsers());
        }

        public async Task<JsonResult> RequestGetUserQuery()
        {
            UserInfo user = await _carUserService.GetUserByIdAsync(_carUserService.GetUsers().Last().Id);
            return Json(user);
        }

        //public async Task<JsonResult> RequestCreateUserQuery()
        //{
        //    RequestRoleIdByAuthId user = new RequestRoleIdByAuthId()
        //    {
        //        Email = "test@test.test",
        //        FirstName = "Иван",
        //        LastName = "Иванов",
        //        NumberPhone = "123456789",
        //        Role = "Партнер"
        //    };
        //    ResponseCreateUserQuery response = await _eventBus.RequestQuery<RequestRoleIdByAuthId, ResponseCreateUserQuery>(user);
        //    return Json(response);
        //}

        //public void PublishDeleteUserByIdEvent()
        //{
        //    Guid id = _carUserService.GetUsers().Last().Id;
        //    _eventBus.PublishEvent(new DeleteUserByIdEvent() { Id = id });
        //}

        //public void PublishUpdateUserEvent()
        //{
        //    var mapper = new Mapper(
        //        new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, UpdateUserEvent>()
        //            .ForMember("Role", opt => opt.Ignore()))
        //    );

        //    UserInfo user = _carUserService.GetUsers().Last();
        //    UpdateUserEvent userEvent = mapper.Map<UpdateUserEvent>(user);
        //    userEvent.FirstName = string.Concat(userEvent.FirstName, "а");
        //    _eventBus.PublishEvent(userEvent);
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
