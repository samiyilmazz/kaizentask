using Kaizen.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonParserController : ControllerBase
    {
        private readonly IParserService _parserService;

        public JsonParserController(IParserService parserService)
        {
            _parserService = parserService;
        }

        [HttpPost]
        public async Task<List<string>> GetJsonParser(SaasRequest[] saasRequest, CancellationToken cancellationToken)
        {
           return await _parserService.ParseSaasJson(saasRequest, cancellationToken);
        }
    }
}
