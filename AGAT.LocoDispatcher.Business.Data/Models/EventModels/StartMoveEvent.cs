using System;

namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    public class StartMoveEvent : MoveEventBase
    {
        public int Direction { get; set; }
        public int DirectionParity { get; set; }
    }
}
