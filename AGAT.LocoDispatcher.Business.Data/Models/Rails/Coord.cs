using AGAT.LocoDispatcher.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Coord: BaseCoord
    {
        [Key]
        public new int Id { get; set; }
        public bool StartFlag { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
        public RoutePlate RoutePlate { get; set; }
    }
}
