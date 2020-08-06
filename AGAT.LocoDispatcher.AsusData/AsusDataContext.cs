﻿using AGAT.LocoDispatcher.AsusData.Models;
using Microsoft.EntityFrameworkCore;

namespace AGAT.LocoDispatcher.AsusData
{
    public class AsusDataContext: DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<CarriageInfo> CarriageInfos { get; set; }
        public DbSet<StationPark> Parks { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StationPark> StationParks { get; set; }
        public AsusDataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionFaccede.GetConnectionString());
        }
    }
}
