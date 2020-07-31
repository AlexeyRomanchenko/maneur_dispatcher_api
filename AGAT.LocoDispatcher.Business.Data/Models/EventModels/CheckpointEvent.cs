namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    public class CheckpointEvent: MoveEventBase
    {
        public CheckpointEvent()
        {

        }
        public int Speed { get; set; } 
    }
}
