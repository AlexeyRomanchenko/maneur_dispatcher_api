using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class ParserBase : IParser
    {
        protected virtual async Task ParseToJson(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData?.Trim()))
            {
                throw new ArgumentNullException("json data is not valid, maybe it is null");
            }

            Console.WriteLine($"Parsing json {jsonData.ToString()}");
        }
    }
}
