using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.RailsModels
{
    public class RoutePlate: Coords
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Angle { get; set; }
    }
}
