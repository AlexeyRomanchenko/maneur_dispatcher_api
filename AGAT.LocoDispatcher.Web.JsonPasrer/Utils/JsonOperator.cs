using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Providers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class JsonOperator : IParser
    {
        private JsonFactory _jsonFactory;
        private ILogger<ParseJob> logger;
        private ProviderFactory _providerFactory;
        public JsonOperator(ILogger<ParseJob> _logger)
        {
            _jsonFactory = new JsonFactory();
            logger = _logger;
            _providerFactory = new ProviderFactory(_logger);
        }
        public async Task ParseToJson(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData?.Trim()))
            {
                throw new ArgumentNullException("json data is not valid, maybe it is null");
            }

            dynamic json = JsonConvert.DeserializeObject<dynamic>(jsonData);
            dynamic jsonArray = json?.response?.events;
            if (jsonArray == null) 
            {
                throw new ArithmeticException("json couldn't be handled");
            }
            foreach (var jsonObject in jsonArray)
            {
                IEvent _event = _jsonFactory.GetEventFactory(jsonObject);
                if (_event == null)
                {
                    throw new ArgumentException("event is not valid");
                }
                IProvider provider = _providerFactory.GetProviderFactory(_event);
                if (provider == null)
                {
                    throw new ArgumentException("provider is not valid");
                }
                await provider.Create(_event);

                Console.WriteLine(_event.Type);
            }
        }
    }
}
