using CarWashAggregator.ApiGateway.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Deamon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAuthService _authorizationService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAuthService authorizationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =
                await _authorizationService.RefreshAccessTokenAsync("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUZXN0IiwidXNlcl9yb2xlIjoidGVzdCIsInVzZXJfcGFzc3dvcmQiOiI1MzJlYWFiZDk1NzQ4ODBkYmY3NmI5YjhjYzAwODMyYzIwYTZlYzExM2Q2ODIyOTk1NTBkN2E2ZTBmMzQ1ZTI1IiwibmJmIjoxNjM0NzY2NzEwLCJleHAiOjE2MzQ3NjcwNzAsImlhdCI6MTYzNDc2NjcxMCwiaXNzIjoiaHR0cHM6Ly9teXdlYmFwaS5jb20iLCJhdWQiOiJodHRwczovL215d2ViYXBpLmNvbSJ9.syxf3KEdpGSEDSOq6s35M6lo5viNXs0T_moIcKwbHk4");
            return Ok("started");
        }
    }
}
