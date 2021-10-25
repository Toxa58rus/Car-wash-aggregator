using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using CarWashAggregator.ApiGateway.Domain.Entities;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    //TODO Add AuthId in UserService (or login)
    [ApiController]
    [Route("")]
    [EnableCors]
    //[EnableCors("MyPolicy")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;
        private readonly IAuthService _authorizationService;
        private readonly IMapper _mapper;
        private readonly IApiGatewayRepository _repository;
        private readonly IUserService _userService;

        public MainController(ILogger<MainController> logger,
            IAuthService authorizationService, IMapper mapper, IApiGatewayRepository repository, IUserService userService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _repository = repository;
            _userService = userService;
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

        [Route("/[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _authorizationService.RegisterNewUserAsync(user);

            if (response.AuthFailure == AuthFailure.None)
            {
                var result = new AuthResult()
                {
                    AccessToken = response.AccessToken,
                    RefreshToken = response.RefreshToken,
                    User = _mapper.Map<AuthenticatedUserModel>(user)
                };
                return Ok(result);
            }
            else
            {
                //TODO Throw Ex
                return HandleAuthFailure(response.AuthFailure);
            }
        }

        [Route("/[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var authResponse = await _authorizationService.LoginUserAsync(user);
            //TODO Request User service

            if (authResponse.AuthFailure == AuthFailure.None)
            {
                var userResponse = await _userService.GetUserById(authResponse.UserId);
                if (userResponse is null)
                    return Problem();
                userResponse.Email = user.Email;
                var result = new AuthResult()
                {
                    AccessToken = authResponse.AccessToken,
                    RefreshToken = authResponse.RefreshToken,
                    User = _mapper.Map<AuthenticatedUserModel>(user)
                };
                return Ok(result);
            }
            else
            {
                //TODO Throw Ex
                return HandleAuthFailure(authResponse.AuthFailure);
            }
        }

        private IActionResult HandleAuthFailure(AuthFailure failure)
        {

            switch (failure)
            {
                case AuthFailure.UserDoesNotExist:
                    return Problem("Incorrect login/password");
                case AuthFailure.UserAlreadyExist:
                    return Problem("Login is already taken");
                case AuthFailure.TokenNotValid:
                    return Problem("Token not valid");
                case AuthFailure.RequestNotValid:
                    return Problem("Request not valid");
                case AuthFailure.ServerError:
                    return Problem("Server error");
                default:
                    return Problem();
            }
        }

        //[Route("/[action]")]
        //[HttpGet]
        //public async Task<IActionResult> AddCity()
        //{
        // await _repository.Add<City>(new City() {Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "Москва"});
        // await _repository.Add(new Car() {Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "A"});
        // await _repository.Add(new Car() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "B" });
        // await _repository.Add(new Car() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "C" });
        // await _repository.Add(new Car() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, Name = "D" });
        // await _repository.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
