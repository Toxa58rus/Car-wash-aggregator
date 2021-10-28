using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    [ApiController]
    [EnableCors]
    public class CarWashesController : Controller
    {
        private readonly ILogger<CarWashesController> _logger;
        private readonly ICarWashService _carWashService;

        public CarWashesController(ILogger<CarWashesController> logger, ICarWashService carWashService)
        {
            _logger = logger;
            _carWashService = carWashService;
        }

        [Route("/car-wash/[action]")]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CarWashSearch query)
        {
            try
            {
                var washes = await _carWashService.SearchAsync(query);
                var result = new ListWashesResult {CarWashes = washes};
                return washes is null ? Ok("no carWashes found") : Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing search");
                throw;
            }
        }

        [Route("/car-wash/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var carWashId))
                    return Problem("cant parse guid");
                var result = await _carWashService.GetById(carWashId);
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
     
        [Route("/car-wash/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var carWashId))
                    return Problem("cant parse guid");

                var washes = await _carWashService.GetByUserId(carWashId);

                var result = new ListWashesResult { CarWashes = washes };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/car-wash/[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarWashAdd request)
        {
            try
            {
                if (await _carWashService.AddCarWash(request))
                {
                    return Ok();
                }
                return Problem("cannot create car wash");
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
    }
}
