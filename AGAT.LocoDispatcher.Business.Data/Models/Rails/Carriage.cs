using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Carriage: BaseCoord
    {
        [Key]
        public new int Id { get; set; }
        public int? Angle { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
    }
}
