using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using CarWashAggregator.Orders.Business.Interfaces;
using CarWashAggregator.Orders.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly IOrderRepository _dbRepository;


        public ApiController(IOrderService orderService, IEventBus bus, IOrderRepository dbRepository)
        {
            _orderService = orderService;
            _dbRepository = dbRepository;
            _bus = bus;
        }

        //[HttpGet]
        //public async Task<IActionResult> IndexAsync()
        //{

        //    var ordersCount = _orderService.GetOrders().ToList().Count;
        //    _bus.PublishEvent(new OrderCreatedEvent());
        //    var ordersQuerys = new List<ResponseOrders>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var order = await _bus.RequestQuery<RequestOrderById, ResponseOrders>(new RequestOrderById() { Id = new Guid("598e5bad-b077-48b0-8ecc-a75fe034742d") });
        //        ordersQuerys.Add(order);
        //    }

        //    var stringBuilder = new StringBuilder();
        //    foreach (var order in ordersQuerys)
        //    {
        //        stringBuilder.Append(order + "---");
        //    }

        //    return Ok("Started, " + stringBuilder);


        //}
    }
}
