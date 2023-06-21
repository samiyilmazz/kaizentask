using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonParserController : ControllerBase
    {
        [HttpPost("parser", Name = "GetJsonParser")]
        public string[] GetJsonParser(SaasRequest[] saasRequest)
        {
            return saasRequest[0].description.Split("\n");
        }
    }
}
