using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Orders.Business.Bus.Querys;
using CarWashAggregator.Orders.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.Orders.Deamon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IEventBus _bus;

        public ApiController(IOrderService orderService, IEventBus bus)
        {
            _orderService = orderService;
            _bus = bus;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                //var ordersCount = _orderService.GetOrders().ToList().Count;
                _bus.RequestQuery(new OrdersQuery());
                return Ok("Started, ");
            }
            catch
            {
                return Ok("Started, no database");
            }
        }
    }
}
