using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    [ApiController]
    [EnableCors]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [Route("/[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var userId))
                    return Problem("cant parse guid");
                var user = await _userService.GetUserById(userId);
                return Ok(new { user.FirstName, user.LastName });
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }



        [Route("/[controller]/[action]")]
        [HttpPut]
        public async Task<IActionResult> Settings([FromBody] UserProfile request)
        {
            try
            {
                if (await _userService.ChangeUserProfile(request))
                {
                    return Ok();
                }
                return Problem("cannot change profile");
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }
    }
}
