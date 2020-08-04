using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class QuartzJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public QuartzJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Где то тут чтото теряется, непонятно что происходит
        public IJob NewJob(TriggerFiredBundle triggerFiredBundle,
        IScheduler scheduler)
        {
            IJobDetail jobDetail = triggerFiredBundle.JobDetail;
            return (IJob)_serviceProvider.GetService(jobDetail.JobType);
        }
        public void ReturnJob(IJob job) { }
    }
}
