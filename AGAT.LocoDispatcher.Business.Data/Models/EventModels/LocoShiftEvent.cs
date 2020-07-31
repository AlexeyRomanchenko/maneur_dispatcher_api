using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGAT.LocoDispatcher.Data.Models.EventModels
{
    [Table("Shifts")]
    public class LocoShiftEvent
    {
        [Key]
        public int Id { get; set; }
        public string TrainNumber { get; set; }
        public string ESR { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime? EndShift { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
