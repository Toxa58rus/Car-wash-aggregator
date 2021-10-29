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
    public class ReviewsController : Controller
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewsController(ILogger<ReviewsController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }


        [Route("/[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var reviewId))
                    return Problem("cant parse guid");
                var result = await _reviewService.GetById(reviewId);
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
        public async Task<IActionResult> GetByUserId([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var reviewId))
                    return Problem("cant parse guid");

                var reviews = await _reviewService.GetByUserId(reviewId);
                var result = new ListReviewsResult() { Reviews = reviews };
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
        public async Task<IActionResult> GetByCarWashId([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var reviewId))
                    return Problem("cant parse guid");

                var reviews = await _reviewService.GetByCarWashId(reviewId);
                var result = new ListReviewsResult() { Reviews = reviews };
                return Ok(result);
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }

        [Route("/[controller]/[action]")]
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
