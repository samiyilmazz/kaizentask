using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Application.Contracts.Implementations
{
    public class GenerateService : IGenerateService
    {
        private readonly HashSet<string> generatedCodeSet = new HashSet<string>();

        public async Task<string> GetRandomCode()
        {
            string generatedCode;
            do
            {
                generatedCode = await GenerateCode();
            } while (!IsUnique(generatedCode));

            if (!IsUnique(generatedCode))
            {
                throw new Exception("Error while creating a new unique code.");
            }

            generatedCodeSet.Add(generatedCode);

            return generatedCode;
        }
        public async Task<string> GenerateCode()
        {
            var allowedChars = "ACDEFGHKLMNPRTXYZ234579";
            var codeLength = 8;

            Random random = new Random();
            char[] codeChars = new char[codeLength];
            for (int i = 0; i < codeLength; i++)
            {
                codeChars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            var response = new string(codeChars);

            return response;
        }

        private bool IsUnique(string code)
        {
            return !generatedCodeSet.Contains(code);
        }
    }
}
