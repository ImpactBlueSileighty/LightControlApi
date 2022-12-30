using LightControlApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using static LightControlApi.Models.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Components.RenderTree;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Components.Web;

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


        // PUT api/<LightController>/5
        [HttpPut("{status}")]
        public IActionResult Put(bool status)
        {
            bool result = false; 
            string json;
            using (StreamReader sr = new StreamReader("JSON/status.json"))
            {

                json = sr.ReadToEnd();
                Data data = JsonConvert.DeserializeObject<Data>(json);
                var jObj = JObject.Parse(json);
                if (jObj == null)
                    return StatusCode(404);

                foreach (var item in jObj.Properties())
                {
                    item.Value = Convert.ToBoolean(item.Value.ToString().Replace(data.Status.ToString(), result.ToString()).ToLower());
                }

                result = (bool)jObj;
            }

            using(StreamWriter sw = new StreamWriter("JSON/status.json"))
            {
                sw.Write(result);
            }

            return Ok();

        }

    }
}
