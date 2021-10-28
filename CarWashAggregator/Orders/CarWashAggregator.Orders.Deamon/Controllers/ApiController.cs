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
using CarWashAggregator.Orders.Domain.Entities;

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

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            //await _dbRepository.Add(new Status() {Name = ""});
            return Ok("Started, ");
        }
    }
}
