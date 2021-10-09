using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Orders.Business.Bus.Querys;
using CarWashAggregator.Orders.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> IndexAsync()
        {

            //var ordersCount = _orderService.GetOrders().ToList().Count;
            //_bus.PublishEvent(new OrderCreatedEvent());
            OrdersQuery ordersQuery = new OrdersQuery();
            ordersQuery = await _bus.RequestQuery(new OrdersQuery() { Orders = new System.Collections.Generic.List<Common.Domain.DTO.Querys.OrderQueryDto>() });
            return Ok("Started, " + ordersQuery);


        }
    }
}
