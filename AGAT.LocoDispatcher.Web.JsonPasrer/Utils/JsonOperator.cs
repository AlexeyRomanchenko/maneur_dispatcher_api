using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Providers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class JsonOperator : IParser
    {
        private JsonFactory _jsonFactory;
        private ProviderFactory _providerFactory;
        public JsonOperator()
        {
            _jsonFactory = new JsonFactory();
            _providerFactory = new ProviderFactory();
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
                provider.Create(_event);

                Console.WriteLine(_event.Type);
            }
        }
    }
}
