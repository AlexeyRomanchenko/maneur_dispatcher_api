﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AGAT.LocoDispatcher.AsusData.Models
{
    [Table("park")]
    public class StationPark
    {
        [Column("prk_id")]
        public int Id { get; set; }
        [Column("num_prk")]
        public string Code { get; set; }
        [Column("stanc")]
        public string StationCode { get; set; }
        [Column("name_park_r")]
        public string Name { get; set; }
    }
}
