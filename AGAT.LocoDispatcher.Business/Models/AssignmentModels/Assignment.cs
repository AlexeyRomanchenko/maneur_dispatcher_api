using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Models.AssignmentModels
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Station { get; set; }
        public string LocomotiveNumber { get; set; }
        public string SerialNumber { get; set; }
        public string WorkCode { get; set; }
        public string PaymentCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? AppliedCode { get; set; }
    }
}
