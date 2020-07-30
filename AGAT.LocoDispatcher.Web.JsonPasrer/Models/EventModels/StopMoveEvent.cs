﻿namespace AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels
{ 
    public class StopMoveEvent: MoveEventBase
    {
    public StopMoveEvent(
        string type,
        int timestamp,
        int distance,
        string checkpointNumber,
        string trackNumber,
        string message,
        string trainId)
    {
        this.Type = type;
        this.Timestamp = timestamp;
        this.Distance = distance;
        this.CheckPointNumber = checkpointNumber;
        this.TrackNumber = trackNumber;
        this.Message = message;
        this.TrainId = trainId;
    }
        public int Distance { get; set; }
    }
}