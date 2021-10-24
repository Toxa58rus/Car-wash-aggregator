using System;
using System.Linq;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AutoMapper;
using CarWashAggregator.ApiGateway.Deamon.Helpers;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using CarWashAggregator.ApiGateway.Domain.Entities;
using CarWashAggregator.ApiGateway.Domain.Models;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestsModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    [ApiController]
    [Route("")]
    [EnableCors]
    //[EnableCors("MyPolicy")]
    public class CarWashAggregatorController : ControllerBase
    {

        private readonly ILogger<CarWashAggregatorController> _logger;
        private readonly IAuthService _authorizationService;
        private readonly IMapper _mapper;
        private readonly IApiGatewayRepository _repository;

        public CarWashAggregatorController(ILogger<CarWashAggregatorController> logger,
            IAuthService authorizationService, IMapper mapper, IApiGatewayRepository repository)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _repository = repository;
        }

        [Route("/[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _authorizationService.RegisterNewUserAsync(user);

            switch (response.AuthFailure)
            {
                case AuthFailure.None:
                {
                    var result = new AuthResult()
                    {
                        AccessToken = response.AccessToken,
                        RefreshToken = response.RefreshToken,
                        User = _mapper.Map<RegisteredUserModel>(user)
                    };
                    return Ok(result);
                }
                //TODO Add Error Responses
                case AuthFailure.UserDoesNotExist:
                    break;
                case AuthFailure.UserAlreadyExist:
                    break;
                case AuthFailure.TokenNotValid:
                    break;
                case AuthFailure.RequestNotValid:
                    break;
                case AuthFailure.ServerError:
                    break;
            }

            return Problem();
        }

        [Route("/[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _authorizationService.LoginUserAsync(user);

            switch (response.AuthFailure)
            {
                case AuthFailure.None:
                {
                    var result = new AuthResult()
                    {
                        AccessToken = response.AccessToken,
                        RefreshToken = response.RefreshToken,
                        User = _mapper.Map<RegisteredUserModel>(user)
                    };
                    return Ok(result);
                }
                //TODO Add Error Responses
                case AuthFailure.UserDoesNotExist:
                    break;
                case AuthFailure.UserAlreadyExist:
                    break;
                case AuthFailure.TokenNotValid:
                    break;
                case AuthFailure.RequestNotValid:
                    break;
                case AuthFailure.ServerError:
                    break;
            }

            return Problem();
        }

        [Route("/[action]")]
        [HttpGet]
        public async Task<IActionResult> AddCity()
        {
	        await _repository.Add<City>(new City() {Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "Москва"});
	        await _repository.Add(new Car() {Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "A"});
	        await _repository.Add(new Car() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "B" });
	        await _repository.Add(new Car() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "C" });
	        await _repository.Add(new Car() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "D" });
	        await _repository.SaveChangesAsync();

            return Ok();
        }

        [Route("/[action]")]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Constants()
        {
            try
            {
                var result = new ConstantsResult
                {
                    Cars = _repository.Get<Car>().ToList(),
                    Cities = _repository.Get<City>().ToList()
                };
                return Ok(result);
            }
            catch
            {
                return Problem();
            }
        }
    }
}
