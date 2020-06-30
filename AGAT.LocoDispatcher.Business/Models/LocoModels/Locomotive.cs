using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AGAT.LocoDispatcher.Data.Models.Rails;

namespace AGAT.LocoDispatcher.Business.Models.LocoModels
{
    public class Locomotive
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Speed { get; set; }
        public string PointId { get; set; }
        public Coords Coords { get; set; }
        public int Angle { get; set; }
    }
}
