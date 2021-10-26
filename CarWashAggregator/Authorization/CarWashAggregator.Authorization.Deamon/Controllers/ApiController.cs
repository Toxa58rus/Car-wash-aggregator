using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Authorization.Domain.Contracts;
using CarWashAggregator.Authorization.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult IndexAsync()
        {
            //_dbRepository.Add(new Role() {IndexId = 0, Name = "User"});
            //_dbRepository.Add(new Role() { IndexId = 1, Name = "Partner" });
            //_dbRepository.SaveChangesAsync();
            return Ok("Started");
        }
    }
}