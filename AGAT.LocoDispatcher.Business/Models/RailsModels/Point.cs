using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.RailsModels
{
    public class Point
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Angle { get; set; }
        public Coords Coord { get; set; }
    }
}
