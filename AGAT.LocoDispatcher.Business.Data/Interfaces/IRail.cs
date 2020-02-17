using AGAT.LocoDispatcher.Data.Models.Rails;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Interfaces
{
    interface IRail
    {
        int Id { get; set; }
        IEnumerable<Coord> Coords{ get;set; }
    }
}
