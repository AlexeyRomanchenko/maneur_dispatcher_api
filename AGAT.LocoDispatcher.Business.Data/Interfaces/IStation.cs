using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.Data.Models.Stations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Interfaces
{
    interface IStation
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<Park> Parks { get; set; }
    }
}
