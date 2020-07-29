﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    [Table("Events")]
    public class MoveEventBase: IEvent
    {
        [Key]
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
