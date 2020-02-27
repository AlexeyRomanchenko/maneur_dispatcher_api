﻿using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.Data.Models.Stations;
using Microsoft.EntityFrameworkCore;

namespace AGAT.LocoDispatcher.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Coord> Coords { get; set; }
        public DbSet<Rail> Rails { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConnectionFactory.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
