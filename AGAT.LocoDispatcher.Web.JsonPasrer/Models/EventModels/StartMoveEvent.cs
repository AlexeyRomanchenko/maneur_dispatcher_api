﻿namespace AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels
{
    public class StartMoveEvent : MoveEventBase
    {
        public StartMoveEvent(
            string type,
            int timestamp,
            int direction,
            int directionParity,
            string message,
            string trainId,
            string trackNumber,
            string checkpointNumber)
        {
            this.Type = type;
            this.Direction = direction;
            this.DirectionParity = directionParity;
            this.Message = message;
            this.Timestamp = timestamp;
            this.TrainId = trainId;
            this.TrackNumber = trackNumber;
            this.CheckPointNumber = checkpointNumber;
        }
        public int Direction { get; set; }
        public int DirectionParity { get; set; }
    }
}
