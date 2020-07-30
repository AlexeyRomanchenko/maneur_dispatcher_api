using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Data;
using AGAT.LocoDispatcher.Data.Models.EventModels;
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
        public DbSet<Park> Parks { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<RoutePlate> RoutePlates { get; set; }
        public DbSet<Locomotive> Locomotives { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<MoveEventBase> Events { get; set; }
        public DbSet<StartMoveEvent> StartEvents { get; set; }
        public DbSet<StopMoveEvent> StopEvents { get; set; }
        public DbSet<CheckpointEvent> CheckpointEvents { get; set; }
        public DbSet<EmergencyEvent> EmergencyEvents { get; set; }
    
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=192.168.111.211;Initial Catalog=LocomotiveDispatcherDB;User ID=web;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//ConnectionFacade.GetConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
