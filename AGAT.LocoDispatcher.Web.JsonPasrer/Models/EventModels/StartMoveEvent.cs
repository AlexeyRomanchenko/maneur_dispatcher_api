namespace AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels
{
    public class StartMoveEvent : MoveEventBase
    {
        public StartMoveEvent(string type, int timestamp, int direction, int directionParity,  string message)
        {
            this.Type = type;
            this.Direction = direction;
            this.DirectionParity = directionParity;
            this.Message = message;
            this.Timestamp = timestamp;
        }
        public int Direction { get; set; }
        public int DirectionParity { get; set; }
    }
}
