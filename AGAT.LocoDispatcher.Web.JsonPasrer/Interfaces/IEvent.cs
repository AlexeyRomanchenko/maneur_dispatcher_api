
namespace AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels
{
    public interface IEvent
    {
        string Type { get; set; }
        int Timestamp { get; set; }
    }
}
