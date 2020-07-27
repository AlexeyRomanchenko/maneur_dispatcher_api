using Quartz;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class Parser : ParserBase, IJob
    {
        private string pathToFile = "D:\\messages.json";
        public async Task Execute(IJobExecutionContext context)
        {
            string json = await GetJSONFromFileAsync(pathToFile);
            await ParseToJson(json);
        }
        protected async Task<string> GetJSONFromFileAsync(string pathToFile)
        {
            try
            {
                if (string.IsNullOrEmpty(pathToFile?.Trim()))
                {
                    throw new ArgumentNullException("Path is not valid");
                }
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    string json = await reader.ReadToEndAsync();
                    return await Task.FromResult(json);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
