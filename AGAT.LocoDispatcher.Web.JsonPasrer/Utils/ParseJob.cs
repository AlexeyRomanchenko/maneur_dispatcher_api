using Quartz;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class ParseJob : IJob
    {
        private DriveOperator _drive;
        public ParseJob()
        {
            _drive = new DriveOperator();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                string path = dataMap.GetString("path");
                if(string.IsNullOrEmpty(path?.Trim()))
                {
                    throw new ArgumentNullException("PATH IS NOT VALID");
                }
                await _drive.GetFilesFromDirectoryAndParseAsync(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}
