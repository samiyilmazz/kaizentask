using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Application.Contracts
{
    public interface IGenerateService
    {
       Task<string> GetRandomCode();
    }
}
