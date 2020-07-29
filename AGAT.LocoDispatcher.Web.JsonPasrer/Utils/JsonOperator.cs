using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class JsonOperator : IParser
    {
        private JsonFactory _jsonFactory;
        private EventProvider _eventProvider;
        public JsonOperator()
        {
            _jsonFactory = new JsonFactory();
            _eventProvider = new EventProvider();
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
                await _eventProvider.CreateDataEvent(_event);
                Console.WriteLine(_event.Type);
            }
        }
    }
}
