using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Authorization.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Deamon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IAuthorizationManager _authorizationManager;
        private readonly IAuthorizationRepository _dbRepository;


        public ApiController(IAuthorizationManager authorizationManager, IAuthorizationRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _authorizationManager = authorizationManager;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var register = await _authorizationManager.RegisterAsync("TestLogin", "TestPassword", "test");
            var token = await _authorizationManager.LoginAsync("TestLogin", "TestPassword", "test");
            var newToken = await _authorizationManager.RefreshAccessTokenAsync(token.RefreshToken);
            return Ok("Started");
        }
    }
}