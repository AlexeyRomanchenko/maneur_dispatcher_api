using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.Data.Models.Stations
{
    public class Station : IStation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Rail> Rails { get; set; }
    }
}
