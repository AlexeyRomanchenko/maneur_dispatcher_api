using Quartz;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class Parser : ParserBase, IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await ParseToJson("wewe");
        }
        protected virtual async Task<string> GetJSONFromFileAsync(string pathToFile)
        {
            try
            {
                if (string.IsNullOrEmpty(pathToFile?.Trim()))
                {
                    throw new ArgumentNullException("Path is not valid");
                }
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    string json = reader.ReadToEnd();
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
