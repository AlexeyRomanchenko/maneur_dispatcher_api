using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.Data.Models.Stations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AGAT.LocoDispatcher.Data.Tests
{

    public class ConnectionStringTests
    {
        private RailsRepository _railsRepository;
        public ConnectionStringTests()
        {
            _railsRepository = new RailsRepository();
        }
        private DbContextOptions<DatabaseContext> GetInMemoryConnection(string databaseName)
        {
            var options =  new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            return options;
        }

        private string _connection = "Server=(localdb)\\mssqllocaldb;Database=locomotiveDB;Trusted_Connection=True;";
        [Fact]
        public void CreateDatabaseOk()
        {
            ConnectionFacade.SetConnectionString(_connection);
            DatabaseContext db = new DatabaseContext();
        }

        [Fact]
        public void SetConnectionStringOK()
        {
            ConnectionFacade.SetConnectionString(_connection);
            string connection = ConnectionFacade.GetConnectionString();
            Assert.NotEqual(0, connection.Length);
        }

        [Fact]
        public void SetConnectionStringThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { ConnectionFacade.SetConnectionString(""); });
        }

        [Fact]
        public void GetConnectionStringOk()
        {
            ConnectionFacade.SetConnectionString(_connection);
            string connection = ConnectionFacade.GetConnectionString();
            _connection.Trim();
            Assert.Equal(_connection, connection);
        }

        [Fact]
        public void TestInMemoryDB()
        {
            var options = this.GetInMemoryConnection(nameof(TestInMemoryDB));
            using (var db = new DatabaseContext(options))
            {
            }
        }

        [Fact]
        public void AddRailsOk()
        {
            IEnumerable<Rail> rails;
            var options = this.GetInMemoryConnection(nameof(AddRailsOk));
            using (var db = new DatabaseContext(options))
            {
                List<Coord> coords = new List<Coord>()
                {
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                };
                db.Rails.Add(new Rail {Coords = coords  });
                db.SaveChanges();
            }

            using (var db = new DatabaseContext(options))
            {
                 rails = db.Rails.Include(e => e.Coords).ToList();
            }
            Assert.NotEmpty(rails);
        }

        [Fact]
        public void GetRailsByStationOK()
        {
            List<Rail> rails = new List<Rail>();
            var options = this.GetInMemoryConnection(nameof(GetRailsByStationOK));
            using (var db = new DatabaseContext(options))
            {
                List<Coord> coords = new List<Coord>()
                {
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                };
                List<Rail> railsMoq = new List<Rail>()
                {
                    new Rail{Coords = coords, RailCode = "T_23" }
                };
                Station station = new Station
                {
                    Name = "TestStation",
                    Rails = railsMoq
                };
                db.Stations.Add(station);
                db.SaveChanges();
            }

            using (var db = new DatabaseContext(options))
            {
                rails = db.Rails.Where(e => e.StationId == 1).Include(e => e.Coords).ToList();
            }

            Assert.NotEmpty(rails);
        }

        [Fact]
        public void CreateRailsRepositoryOk()
        {
            ConnectionFacade.SetConnectionString(_connection);
            List<Coord> coords = new List<Coord>()
                {
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                    new Coord { StartFlag = false, X = 34, Y = 32 },
                    new Coord { StartFlag = false, X = 35, Y = 32 },
                    new Coord { StartFlag = false, X = 36, Y = 32 },
                    new Coord { StartFlag = false, X = 37, Y = 32 },
                };
            Station station = new Station()
            {
                Name = "Test"
            };
            int stationId = 0;
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Stations.Add(station);
                db.SaveChanges();
                stationId = db.Stations.Where(e => e.Name == "Test").Select(e => e.Id).FirstOrDefault();
            }
            Rail rail = new Rail()
            {
               Coords = coords,
               RailCode = "H_2",
               StationId = stationId
            };
            _railsRepository.Create(rail);
            using (DatabaseContext db = new DatabaseContext())
            {
                var stat = db.Stations.FirstOrDefault();
                db.Stations.Remove(stat);
                db.SaveChanges();
            }
        }
    }
}
