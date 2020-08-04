using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class DriveOperator
    {
        private JsonOperator _json;
        private ILogger<ParseJob> _logger;
        public DriveOperator(ILogger<ParseJob> logger)
        {
            _logger = logger;
            _json = new JsonOperator(logger);
        }
        public async Task<string> GetJSONFromFileAsync(string pathToFile)
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

        public async Task GetFilesFromDirectoryAndParseAsync(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (var filePath in files)
                    {
                        try
                        {
                            FileInfo file = new FileInfo(filePath);
                            string json = await GetJSONFromFileAsync(filePath);
                            await _json.ParseToJson(json);
                            file.Delete();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                       
                    }
                }
                else
                {
                    throw new ArgumentNullException("directory doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
