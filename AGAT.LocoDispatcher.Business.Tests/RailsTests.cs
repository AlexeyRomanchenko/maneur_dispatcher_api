using AGAT.LocoDispatcher.Business.Classes;
using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mapper = AGAT.LocoDispatcher.Business.Config.Mapper;

namespace AGAT.LocoDispatcher.Business.Tests
{
    public class RailsTests
    {
        [Fact]
        public void GetStationRailsOk()
        {
            RailsManager railManager = new RailsManager();
            var stationScheme = railManager.GetRailsScheme();
            Assert.NotEmpty(stationScheme);
        }

        [Fact]
        public void MapperInstanceOk()
        {
            Data.Models.Rails.Coord crd = new Data.Models.Rails.Coord
            {
                Id = 1,
                X = 2,
                Y = 3,
                StartFlag = true
            };
            Data.Models.Rails.Coord crd2 = new Data.Models.Rails.Coord
            {
                Id = 1,
                X = 2,
                Y = 3,
                StartFlag = false
            };

            List<Data.Models.Rails.Coord> coords = new List<Data.Models.Rails.Coord>()
            {
                crd,crd2,crd2
            };

            IMapper _mapper = Mapper.GetMapperInstance();
            
            List<Coords> coords1 = _mapper.Map<List<Coords>>(coords);
            Rail rail = new Rail
            {
                startX = 43,
                startY = 23,
                Coords = coords1,
                Status = 7,
                Id = 3
            };

            Data.Models.Rails.Rail railDbo = _mapper.Map<Data.Models.Rails.Rail>(rail);
        }
    }
}
