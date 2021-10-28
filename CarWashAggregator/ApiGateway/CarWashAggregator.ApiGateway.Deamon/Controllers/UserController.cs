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
    [Route("/user")]
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


        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] ReviewGet request)
        {
            try
            {
                if (!Guid.TryParse(request.Id, out var id))
                    return Problem("cant parse guid");
                var user = await _userService.GetUserById(id);
                return Ok(new { user.FirstName, user.LastName });
            }
            catch
            {
                _logger.LogError("error in executing");
                throw;
            }
        }



        [Route("/[action]")]
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
