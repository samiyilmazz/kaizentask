using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Application.Contracts
{
    public interface IParserService
    {
        Task<List<string>> ParseSaasJson(SaasRequest[] saasRequests, CancellationToken cancellationToken);
    }
}
