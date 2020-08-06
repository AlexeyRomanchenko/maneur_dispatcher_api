using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories;
using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.Data.Models.Stations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.Data.Tests
{

    public class EventRepositoryUnitTests
    {
        private BaseEventRepository _eventRepository;
        public EventRepositoryUnitTests()
        {
            _eventRepository = new BaseEventRepository();
        }
      

        private string _connection = "Server=(localdb)\\mssqllocaldb;Database=locomotiveDB;Trusted_Connection=True;";
        [Theory]
        [InlineData(37)]
        public async Task GetLastEventOk (int id)
        {
            ConnectionFacade.SetConnectionString(_connection);
            DatabaseContext db = new DatabaseContext();
            await _eventRepository.GetLastEventByShiftIdAsync(id);
        }

    }
}
