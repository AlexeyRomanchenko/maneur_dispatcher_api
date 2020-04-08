using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Config
{
    public class Mapper
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

                // Mapping classes from DataLayer to Business
                cfg.CreateMap<Data.Models.Rails.Rail, Rail>()
                .ForMember(e => e.id, dto => dto.MapFrom(e => e.Id))
                .ForMember(e => e.railCode, dto => dto.MapFrom(e => e.RailCode))
                .ForMember(e => e.Coords, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == false).ToList()))
                .ForMember(e => e.startX, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.X).FirstOrDefault()))
                .ForMember(e => e.startY, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.Y).FirstOrDefault()));

                //Mapping data from Business layer to DataLayer 
                cfg.CreateMap<Rail, Data.Models.Rails.Rail>()
                .ForMember(dto => dto.Id, e => e.Ignore())
                .ForMember(dto => dto.RailCode, e => e.MapFrom(e => e.id.ToString()))
                .ForMember(dto => dto.Coords, e => e.MapFrom(e => e.Coords))
                .AfterMap((orig, dest)=> 
                {
                    Data.Models.Rails.Coord startCoord = new Data.Models.Rails.Coord
                    {
                        X = orig.startX,
                        Y = orig.startY,
                        StartFlag = true
                    };
                    dest.Coords = dest.Coords.Append(startCoord).ToList();
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
