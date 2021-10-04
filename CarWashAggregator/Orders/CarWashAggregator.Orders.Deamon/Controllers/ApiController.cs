using CarWashAggregator.Orders.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarWashAggregator.Orders.Deamon.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            try
            {
                var ordersCount = _orderService.GetOrders().ToList().Count;
                return Ok("Started, " + ordersCount);
            }
            catch
            {
                return Ok("Started, no database");
            }
        }

    }
}
