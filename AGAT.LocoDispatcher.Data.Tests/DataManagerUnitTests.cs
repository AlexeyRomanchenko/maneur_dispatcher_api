using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.Data.Models.Stations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.Data.Tests
{

    public class DataManagerUnitTests
    {
        private DataManager manager;
        public DataManagerUnitTests()
        {
            manager = new DataManager();
        }
        [Fact]
        public async Task GetStartEvents()
        {
            var events = await manager.startEventRepository.GetAsync();
            Assert.NotEmpty(events);
        }

        [Fact]
        public async Task GetStopEvents()
        {
            var events = await manager.stopEventRepository.GetStopAsync();
            Assert.NotEmpty(events);
        }

        [Fact]
        public async Task GetStopOutsideEvents()
        {
            var events = await manager.stopEventRepository.GetStopOutsideAsync();
            Assert.NotEmpty(events);
        }

        [Fact]
        public async Task GetEmergencyEvents()
        {
            var events = await manager.emergencyRepository.GetAsync();
            Assert.NotEmpty(events);
        }

        [Fact]
        public async Task GetCheckpointEvents()
        {
            var events = await manager.checkpointEventRepository.GetAsync();
            Assert.NotEmpty(events);
        }
    }
}
