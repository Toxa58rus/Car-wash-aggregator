using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Querys;
using CarWashAggregator.Orders.Business.Bus.Querys;
using CarWashAggregator.Orders.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var ordersQuerys = new List<OrdersQuery>();
            for (int i = 0; i < 10; i++)
            {
                ordersQuerys.Add(await _bus.RequestQuery(new OrdersQuery()
                { Orders = new List<OrderQueryDto>() { new OrderQueryDto() { Price = i } } }));
            }

            var stringBuilder = new StringBuilder();
            foreach (var order in ordersQuerys.SelectMany(ordersQuery => ordersQuery.Orders))
            {
                stringBuilder.Append(order.Price + "---");
            }

            return Ok("Started, " + stringBuilder);


        }
    }
}
