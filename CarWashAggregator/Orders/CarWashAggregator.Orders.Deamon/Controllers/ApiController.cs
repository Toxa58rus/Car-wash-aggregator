using CarWashAggregator.Orders.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.Orders.Deamon.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public ApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("started");
        }
    }
}
