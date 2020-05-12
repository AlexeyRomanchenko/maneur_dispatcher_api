﻿using AGAT.LocoDispatcher.AsusData.Models;
using Microsoft.EntityFrameworkCore;

namespace AGAT.LocoDispatcher.AsusData
{
    public class AsusDataContext: DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<StationPark> Parks { get; set; }
        public AsusDataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.111.211;User ID=web;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }
    }
}
