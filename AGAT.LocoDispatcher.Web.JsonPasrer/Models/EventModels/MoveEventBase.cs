using AGAT.LocoDispatcher.Data.Models.EventModels;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels
{ 
    public class MoveEventBase: IEvent
    {
        public int Id { get; set; } 
        public string Type { get; set; }
        public int Timestamp { get; set; }
        public string Message { get; set; }
        public string TrackerId { get; set; }
        public string TrainId { get; set; }
        public string CheckPointNumber { get; set; }
        public string TrackNumber { get; set; }
    }
}
