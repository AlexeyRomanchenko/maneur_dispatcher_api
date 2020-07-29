namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    public class StartMoveEvent : MoveEventBase
    {
        public StartMoveEvent(string type, int timestamp, int direction, int directionParty,  string message)
        {
            this.Type = type;
            this.Direction = direction;
            this.DirectionParty = directionParty;
            this.Message = message;
            this.Timestamp = timestamp;
        }
        public int Direction { get; set; }
        public int DirectionParty { get; set; }
    }
}
