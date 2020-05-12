using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.RailsModels
{
    public class Park
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<Rail> Rails { get; set; }
        public int ParkId { get; set; }
    }
}
