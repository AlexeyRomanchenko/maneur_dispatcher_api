using AGAT.LocoDispatcher.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Rail : IRail
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<Coord> Coords { get; set; }
    }
}
