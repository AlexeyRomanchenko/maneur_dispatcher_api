using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using Quartz;
using Quartz.Impl;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Schedulers
{
    public class EventScheduler: ITypeScheduler
    {
        public async static void Start() 
        {
            IScheduler _scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await _scheduler.Start();

            IJobDetail parserJob = JobBuilder.Create<ParseJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(e => 
                    e.WithIntervalInSeconds(5)
                    .WithRepeatCount(0))
                .Build();
            await _scheduler.ScheduleJob(parserJob, trigger);
        }
    }
}
