using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Application.Contracts.Implementations
{
    public class ParserService : IParserService
    {
        public async Task<List<string>> ParseSaasJson(SaasRequest[] saasRequest, CancellationToken cancellationToken)
        {

            IDictionary<List<int>, string> response = new Dictionary<List<int>, string>();

            for (int i = 1; i < saasRequest.Length; i++)
            {
                if (i == 1)
                {
                    AddToList(saasRequest, response, i);
                }
                else
                {
                    var centerOfSquare = ((saasRequest[i].boundingPoly.vertices[2].y - saasRequest[i].boundingPoly.vertices[0].y) / 2) + saasRequest[i].boundingPoly.vertices[0].y;
                    var index = response.FirstOrDefault(x => x.Key[0] < centerOfSquare && centerOfSquare < x.Key[3]);

                    if (index.Value != null)
                    {
                        response[index.Key] = index.Value + " " + saasRequest[i].description;
                    }
                    else
                    {
                        AddToList(saasRequest, response, i);
                    }
                }
            }

            return response.Values.ToList();
        }
        private static void AddToList(SaasRequest[] saasRequest, IDictionary<List<int>, string> response, int i)
        {
            var area = new List<int>();
            area.Add(saasRequest[i].boundingPoly.vertices[0].y);
            area.Add(saasRequest[i].boundingPoly.vertices[1].y);
            area.Add(saasRequest[i].boundingPoly.vertices[2].y);
            area.Add(saasRequest[i].boundingPoly.vertices[3].y);

            response.Add(area, saasRequest[i].description);
        }
    }
}
