using AGAT.LocoDispatcher.Business.Models.RailsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.LocoModels
{
    public class LocomotiveViewModel: Locomotive
    {
        public string PointId { get; set; }
        public Coords Coords { get; set; }
        public int Angle { get; set; }
    }
}
