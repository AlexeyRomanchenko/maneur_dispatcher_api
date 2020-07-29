using Quartz;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class ParseJob : IJob
    {
        private DriveOperator _drive;
        private JsonOperator _jsonOperator;
        public ParseJob()
        {
            _drive = new DriveOperator();
            _jsonOperator = new JsonOperator();
        }
        private string pathToFile = "D:\\json/messages.json";
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                string json = await _drive.GetJSONFromFileAsync(pathToFile);
                _jsonOperator.ParseToJson(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}
