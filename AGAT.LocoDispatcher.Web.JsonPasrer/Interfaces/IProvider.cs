using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces
{
    public interface IProvider
    {
        Task Create(IEvent _event);
    }
}
