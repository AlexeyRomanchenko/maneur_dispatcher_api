using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Config
{
    public static class Mapper
    {
        private static IMapper _mapper;
        static Mapper()
        {
            
            MapperConfiguration config = new MapperConfiguration(
            cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Data.Models.Rails.Coord, Coords>()
                .ForMember(e=>e.X, e=>e.MapFrom(e=>e.X))
                .ForMember(e => e.Y, e => e.MapFrom(e => e.Y))
                .ReverseMap();

                //cfg.CreateMap<Data.Models.Rails.Rail, Rail>()
                //.ForMember(e => e.Id, dto => dto.MapFrom(e => e.Id))
                //.ForMember(e => e.Coords, dto => dto.MapFrom(e => e.Coords))
                //.ForMember(e => e.startX, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.X).FirstOrDefault()))
                //.ForMember(e => e.startY, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.Y).FirstOrDefault()));

                cfg.CreateMap<Rail, Data.Models.Rails.Rail>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.Coords, e => e.MapFrom(e => e.Coords))
                .AfterMap((orig, dest)=> 
                {
                    Data.Models.Rails.Coord startCoord = new Data.Models.Rails.Coord
                    {
                        X = orig.startX,
                        Y = orig.startY,
                        StartFlag = true
                    };
                    IEnumerable<Data.Models.Rails.Coord> startCoords = new[] {startCoord };
                    dest.Coords = dest.Coords.Concat(startCoords);

                });
            });
            _mapper = config.CreateMapper();
        }

        public static IMapper GetMapperInstance()
        {
            return _mapper;
        }
            
    }
}
