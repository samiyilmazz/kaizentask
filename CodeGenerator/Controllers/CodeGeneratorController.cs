using Kaizen.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeGeneratorController : ControllerBase
    {
        private readonly IGenerateService _generateService;

        public CodeGeneratorController(IGenerateService generateService)
        {
            _generateService = generateService;
        }

        [HttpGet]
        public async Task<string> GetRandomCode(CancellationToken cancellationToken)
        {
            return await _generateService.GetRandomCode(cancellationToken);
        }
    }
}