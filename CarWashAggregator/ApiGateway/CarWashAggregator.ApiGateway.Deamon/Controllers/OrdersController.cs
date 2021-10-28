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
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;

        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }


        [Route("/[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var orderId))
                    return Problem("cant parse guid");
                var result = await _orderService.GetById(orderId);
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId([FromRoute] string id, [FromQuery] string status)
        {
            try
            {
                if (!Guid.TryParse(id, out var orderId))
                    return Problem("cant parse guid");

                var orders = await _orderService.GetByUserId(orderId, status);
                var result = new ListOrdersResult { Orders = orders };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
        [Route("/[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByCarWashId([FromRoute] string id, [FromQuery] string filterDate)
        {
            try
            {
                if (!Guid.TryParse(id, out var orderId))
                    return Problem("cant parse guid");
                DateTime? dateFilter = null;
                if (!string.IsNullOrWhiteSpace(filterDate))
                {
                    if (!DateTime.TryParse(filterDate, out var date))
                    {
                        _logger.LogError("error in parsing date");
                        return Problem("cant parse date");
                    }
                    dateFilter = date;
                }
                var orders = await _orderService.GetByCarWashId(orderId, dateFilter);
                var result = new ListOrdersResult { Orders = orders };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> Statuses()
        {
            try
            {
                var statuses = await _orderService.GetOrderStatuses();
                var result = new StatusesResult { Statuses = statuses };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[controller]/[action]")]
        [HttpPut]
        public async Task<IActionResult> Statuses(string status, string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var orderId))
                    return Problem("cant parse guid");
                var result = await _orderService.ChangeStatus(status, orderId);
                return result ? (IActionResult)Ok() : Problem("cant change status");
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderAdd request)
        {
            try
            {
                if (await _orderService.AddOrder(request))
                {
                    return Ok();
                }
                return Problem("cannot create order");
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
    }
}
