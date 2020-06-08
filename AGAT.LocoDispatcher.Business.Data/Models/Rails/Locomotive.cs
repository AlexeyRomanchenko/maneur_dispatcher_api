using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Locomotive: BaseCoord
    {
        public bool Status { get; set; }
        public int Angle { get; set; }
    }
}
