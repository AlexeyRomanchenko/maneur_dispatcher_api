namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    public class EmergencyEvent: MoveEventBase
    {
        public string EmergencyType { get; set; }
        public int EmergencyStatus { get; set; }
        
    }
}
