using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class ParseJob : IJob
    {
        private DriveOperator _drive;
        private ILogger<ParseJob> logger;

        public ParseJob(ILogger<ParseJob> _logger)
        {
            _drive = new DriveOperator(_logger);
            logger = _logger;
            logger.LogInformation($"{DateTime.Now} PARSE JOB LAUNCHED");
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                string path = dataMap.GetString("path");
                if (string.IsNullOrEmpty(path?.Trim()))
                {
                    throw new ArgumentNullException("PATH IS NOT VALID");
                }
                await _drive.GetFilesFromDirectoryAndParseAsync(path);
            }
            catch (Exception ex)
            {
                logger.LogError($"{DateTime.Now} PARSE JOB FILE Exception: { ex.Message}");
                throw ex;
            }

        }
       
    }
}
