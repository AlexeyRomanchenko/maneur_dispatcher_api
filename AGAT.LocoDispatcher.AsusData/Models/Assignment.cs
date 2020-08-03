using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AGAT.LocoDispatcher.AsusData.Models
{
    [Table("LokM_operWork")]
    public class Assignment
    {
        [Column("stanc")]
        public string Station { get; set; }
        [Column("num_lok")]
        public string LocomotiveNumber { get; set; }
        [Column("ser_lok")]
        public string SerialNumber { get; set; }
        [Column("cod_work")]
        public string WorkCode { get; set; }
        [Column("cod_opL")]
        public string PaymentCode { get; set; }
        [Column("dt_beg")]
        public DateTime StartDate { get; set; }
        [Column("dt_end")]
        public DateTime EndDate { get; set; }
    }
}
