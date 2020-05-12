using AGAT.LocoDispatcher.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class BaseCoord : ICoord
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
