
namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    public interface IEvent
    {
        string Type { get; set; }
        int Timestamp { get; set; }
    }
}
