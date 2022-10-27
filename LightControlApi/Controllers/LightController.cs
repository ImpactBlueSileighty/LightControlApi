using LightControlApi.Models;
using Microsoft.AspNetCore.Mvc;
using static LightControlApi.Models.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LightControlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightController : ControllerBase
    {
        // GET: api/<LightController>
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(new Data() { Id = 1});

        }

        // GET api/<LightController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LightController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<LightController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
