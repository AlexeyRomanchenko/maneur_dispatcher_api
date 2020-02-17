using AGAT.LocoDispatcher.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.RailsModels
{
    public class Rail : IRail
    {
        public int Id { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int Status { get; set; }
        public IEnumerable<Coords> Coords {get; set;}
    }
}
