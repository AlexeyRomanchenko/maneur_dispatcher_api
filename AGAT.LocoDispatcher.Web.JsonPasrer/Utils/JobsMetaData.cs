using System;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class JobsMetadata
    {
        public Guid JobId { get; set; }
        public Type JobType { get; }
        public string JobName { get; }
        public string Path { get; }
        public int Period { get; }
        public JobsMetadata(Guid Id, Type jobType, string jobName,
        int period, string path)
        {
            JobId = Id;
            JobType = jobType;
            JobName = jobName;
            Path = path;
            Period = period;
        }
    }
}
