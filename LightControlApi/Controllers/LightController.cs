using LightControlApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
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
            Data data;
            using (StreamReader sr = new StreamReader("JSON/status.json"))
            {
                string json = sr.ReadToEnd();
                data = JsonConvert.DeserializeObject<Data>(json);
            }

            return new ObjectResult(new Data { Status = data.Status });
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
