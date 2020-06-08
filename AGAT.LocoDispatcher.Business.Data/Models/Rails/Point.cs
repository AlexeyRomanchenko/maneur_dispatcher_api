using AGAT.LocoDispatcher.Data.Models.Stations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Point
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Angle { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
    }
}
