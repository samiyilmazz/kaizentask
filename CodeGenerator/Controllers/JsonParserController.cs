using Microsoft.AspNetCore.Mvc;


namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonParserController : ControllerBase
    {
        [HttpGet("parser", Name = "GetJsonParser")]
        public ActionResult<string> GetJsonParser()
        {
            return Ok();
        }
    }
}
