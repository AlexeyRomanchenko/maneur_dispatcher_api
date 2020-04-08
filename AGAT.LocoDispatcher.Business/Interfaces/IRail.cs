using AGAT.LocoDispatcher.Business.Models.RailsModels;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.Business.Interfaces
{
    interface IRail
    {
        int id { get; set; }
        int Status { get; set; }
        IEnumerable<Coords> Coords { get; set; }

    }
}
