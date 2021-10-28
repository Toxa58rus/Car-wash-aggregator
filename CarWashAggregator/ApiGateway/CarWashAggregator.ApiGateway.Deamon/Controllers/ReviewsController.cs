using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Business.Services;
using CarWashAggregator.ApiGateway.Domain.Models;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    [ApiController]
    [Route("/reviews")]
    [EnableCors]
    public class ReviewsController : Controller
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewsController(ILogger<ReviewsController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }


        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] ReviewGet request)
        {
            try
            {
                if (!Guid.TryParse(request.Id, out var id))
                    return Problem("cant parse guid");
                var result = await _reviewService.GetById(id);
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
     
        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId([FromRoute] ReviewGet request)
        {
            try
            {
                if (!Guid.TryParse(request.Id, out var id))
                    return Problem("cant parse guid");

                var reviews = await _reviewService.GetByUserId(id);
                var result = new ListReviewsResult() { Reviews = reviews };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetByCarWashId([FromRoute] ReviewGet request)
        {
            try
            {
                if (!Guid.TryParse(request.Id, out var id))
                    return Problem("cant parse guid");

                var reviews = await _reviewService.GetByCarWashId(id);
                var result = new ListReviewsResult() { Reviews = reviews };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReviewAdd request)
        {
            try
            {
                if (await _reviewService.AddReview(request))
                {
                    return Ok();
                }
                return Problem("cannot create review");
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
    }
}
