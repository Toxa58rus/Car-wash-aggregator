using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.CarWashes.Deamon.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly ICarWashService _carWashService;

        public TestController(ICarWashService carWashService)
        {
            _carWashService = carWashService;
        }

        public JsonResult GetCarWashes()
        {
            return Json(_carWashService.GetCarWashes());
        }

        public async Task<string> CreateCarWash()
        {
            CarWash carWash = new CarWash();
            await _carWashService.CreateCarWashAsync(carWash);
            return carWash.Id.ToString();
        }
    }
}
