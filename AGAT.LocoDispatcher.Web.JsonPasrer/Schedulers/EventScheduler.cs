using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Schedulers
{
    public class EventScheduler: ITypeScheduler
    {
        public async static void Start() 
        {
            IScheduler _scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await _scheduler.Start();
        }
    }
}
