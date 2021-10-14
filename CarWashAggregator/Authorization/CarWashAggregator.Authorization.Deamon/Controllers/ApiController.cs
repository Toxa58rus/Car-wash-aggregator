using CarWashAggregator.Authorization.Domain.Contracts;
using CarWashAggregator.Common.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.Authorization.Deamon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly IAuthorizationRepository _dbRepository;


        public ApiController(IEventBus bus, IAuthorizationRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _bus = bus;
        }

        [HttpGet]
        public IActionResult IndexAsync()
        {
            return Ok("Started");
        }
    }
}