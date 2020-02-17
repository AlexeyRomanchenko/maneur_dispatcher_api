using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Interfaces
{
    interface ICoord
    {
        int Id { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}
