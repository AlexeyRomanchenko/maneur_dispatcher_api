using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Stations
{
    public class Park: IPark
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<Rail> Rails { get; set; }
        public int ParkId { get; set; }
    }
}
