using AGAT.LocoDispatcher.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Coord: ICoord
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool StartFlag { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
    }
}
