using AGAT.LocoDispatcher.Data.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using Newtonsoft.Json;
using System;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class JsonOperator : IParser
    {
        private JsonFactory _jsonFactory;
        public JsonOperator()
        {
            _jsonFactory = new JsonFactory();
        }
        public void ParseToJson(string jsonData)
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
                Console.WriteLine(_event.Type);
            }
        }
    }
}
