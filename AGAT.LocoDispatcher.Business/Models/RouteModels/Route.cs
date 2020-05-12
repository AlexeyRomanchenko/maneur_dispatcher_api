using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.RouteModels
{
    public class Route
    {
        public int Id { get; set; }
        public short CarCount { get; set; }
        public int CarWeight { get; set; }
         public int CarLength { get; set; }
        public string RouteNumber { get; set; }
        public int ParkId { get; set; }
    }
}
