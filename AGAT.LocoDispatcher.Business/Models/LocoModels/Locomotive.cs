using AGAT.LocoDispatcher.Data.Models.Rails;

namespace AGAT.LocoDispatcher.Business.Models.LocoModels
{
    public class Locomotive
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public Coord Coord { get; set; }
    }
}
