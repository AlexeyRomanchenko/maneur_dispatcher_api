﻿using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Stations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Rail : IRail
    {
        [Key]
        public int Id { get; set; }
        public string RailCode { get; set; }
        public IEnumerable<Coord> Coords { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public Carriage Carriage { get; set; }
        public RoutePlate RoutePlate { get; set; }
    }
}
