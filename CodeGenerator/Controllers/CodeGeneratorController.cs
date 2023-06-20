using Microsoft.AspNetCore.Mvc;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeGeneratorController : ControllerBase
    {
        private readonly HashSet<string> GeneratedCodeSet = new HashSet<string>();

        [HttpGet("random", Name = "GetRandomCode")]
        public ActionResult<string> GetRandomCode()
        {
            string generatedCode;
            do
            {
                generatedCode = GenerateCode();
            } while (!IsUnique(generatedCode));

            if (!IsUnique(generatedCode))
            {
                throw new Exception("Error while creating a new unique code.");
            }

            GeneratedCodeSet.Add(generatedCode);
            return Ok(generatedCode);
        }

        private string GenerateCode()
        {
            const string allowedChars = "ACDEFGHKLMNPRTXYZ234579";
            const int codeLength = 8;

            Random random = new Random();
            char[] codeChars = new char[codeLength];
            for (int i = 0; i < codeLength; i++)
            {
                codeChars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }
            return new string(codeChars);
        }

        private bool IsUnique(string code)
        {
            return !GeneratedCodeSet.Contains(code);
        }
    }
}