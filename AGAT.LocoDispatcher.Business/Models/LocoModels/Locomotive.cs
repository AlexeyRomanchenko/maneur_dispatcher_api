using System;

namespace AGAT.LocoDispatcher.Business.Models.LocoModels
{
    public class Locomotive
    {
        public int Id { get; set; }
        public string TrainNumber { get; set; }
        public string ESR { get; set; }
        public bool IsValid { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime? EndShift { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
