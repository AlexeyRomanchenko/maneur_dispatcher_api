using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class RoutePlate : BaseCoord
    {
        [Key]
        public new int Id { get; set; }
        public string Name { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
        public int Angle { get; set; }
    }
}
