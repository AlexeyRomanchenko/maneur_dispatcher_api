using Quartz;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class Parser : ParserBase, IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await ParseToJson("wewe");
        }
    }
}
