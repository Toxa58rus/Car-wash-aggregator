using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWashAggregator.Orders.Business.interfaces;
using System.Collections;
using CarWashAggregator.User.Domain.Enities;

namespace CarWashAggregator.User.Deamon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly IUserService _carUserService;
        public ValuesController(IUserService carUserService)
        {
            _carUserService = carUserService;
        }
        // GET api/values
        [HttpGet]
        public Task<JsonResult> Get()
        {
            return Json(await _carUserService.GetUsers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
