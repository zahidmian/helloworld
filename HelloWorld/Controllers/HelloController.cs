using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {        
        private CustomWriters.ICustomWriter _writer;
        private readonly IConfiguration _configuration;

        public HelloController(IConfiguration configuration)
        {
            // if default writer is defined in configuration, then that instead
            if (configuration != null)
            {
                _configuration = configuration;
                var to = _configuration.GetValue("DefaultWriter", "console");
                _writer = CustomWriters.WriterFactory.createWriter(to);
            }
            else
            {
                _writer = CustomWriters.WriterFactory.createWriter("console");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] JsonElement body)
        {
            // probably better ways to extract data, but good enough for now
            string json = System.Text.Json.JsonSerializer.Serialize(body);
            var obj = JObject.Parse(json);
            
            JToken token;
            var to = "";
            var text = "";

            if (obj.TryGetValue("text", out token)){
                text = token.Value<string>();
            }
            else
            {
                // assume that this is a bad request
                return BadRequest("text is required");
            }

            if (obj.TryGetValue("writeTo", out token))
            {
                to = token.Value<string>();
                // overwrite default writer
                _writer = CustomWriters.WriterFactory.createWriter(to);
            }
             
            _writer.WriteLine(text);
            return Ok($"\"{text}\" was written to {_writer.GetType().ToString()}");

        }

    }
}
