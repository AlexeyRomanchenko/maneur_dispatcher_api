namespace AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels
{
    public class EmergencyEvent: MoveEventBase
    {
        public EmergencyEvent(
            string type,
            int timestamp,
            string trainId,
            string emergencyType,
            int emergencyStatus,
            string message)
        {
            this.Type = type;
            this.Timestamp = timestamp;
            this.TrainId = trainId;
            this.EmergencyType = emergencyType;
            this.EmergencyStatus = emergencyStatus;
            this.Message = message;
        }
        public string EmergencyType { get; set; }
        public int EmergencyStatus { get; set; }
        
    }
}
