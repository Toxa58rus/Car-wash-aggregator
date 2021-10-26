using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    [ApiController]
    [Route("/car-wash")]
    [EnableCors]
    public class CarWashesController : Controller
    {
        private readonly ILogger<CarWashesController> _logger;
        private readonly IMapper _mapper;
        private readonly IApiGatewayRepository _repository;
        private readonly ICarWashService _carWashService;

        public CarWashesController(ILogger<CarWashesController> logger, IMapper mapper, IApiGatewayRepository repository, ICarWashService carWashService)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _carWashService = carWashService;
        }

        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CarWashSearch query)
        {
            try
            {
                var result = await _carWashService.SearchAsync(query);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
          
        }

        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> Get(CarWashGet request)
        {
            //var result = await _carWashService.SearchAsync();
            return Ok();
        }
    }
}
