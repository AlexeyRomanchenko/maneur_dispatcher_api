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

                cfg.CreateMap<AGAT.LocoDispatcher.AsusData.Models.Route, Models.RouteModels.Route>().ReverseMap();

                cfg.CreateMap<Data.Models.Rails.Coord, Coords>()
                .ForMember(e => e.X, e => e.MapFrom(e => e.X))
                .ForMember(e => e.Y, e => e.MapFrom(e => e.Y)).ReverseMap();

                // Mapping classes from DataLayer to Business

                cfg.CreateMap<Data.Models.Rails.Rail, Rail>()
                .ForMember(e => e.id, dto => dto.MapFrom(e => e.Id))
                .ForMember(e => e.railCode, dto => dto.MapFrom(e => e.RailCode))
                .ForMember(e => e.Coords, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == false).ToList()))
                .ForMember(e => e.startX, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.X).FirstOrDefault()))
                .ForMember(e => e.startY, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.Y).FirstOrDefault()))
                .ForMember(e=>e.Carriage, dto=>dto.MapFrom(e=>e.Carriage))
                .ForMember(e=>e.Label, dto=> dto.MapFrom(e=>e.RoutePlate));

                cfg.CreateMap<Data.Models.Rails.Carriage, Carriage>()
                .ForMember(e => e.Id, e=> e.MapFrom(e=>e.Id));

                cfg.CreateMap<Data.Models.Rails.RoutePlate, RoutePlate>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.Angle, e => e.MapFrom(e => e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(e => e.X))
                .ForMember(e => e.Y, e => e.MapFrom(e => e.Y))
                .ForMember(e => e.Name, e => e.MapFrom(e => e.Name));

                cfg.CreateMap<Data.Models.Stations.Park, Park>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.Name, e => e.MapFrom(e => e.Name))
                .ForMember(e => e.ParkId, e => e.MapFrom(e => e.ParkId))
                .ForMember(e => e.Rails, e => e.MapFrom(e => e.Rails))
                .ForMember(e => e.Code, e => e.MapFrom(e => e.Code));

                //Mapping data from Business layer to DataLayer 
                cfg.CreateMap<Rail, Data.Models.Rails.Rail>()
                .ForMember(dto => dto.Id, e => e.Ignore())
                .ForMember(dto => dto.RailCode, e => e.MapFrom(e => e.railCode))
                .ForMember(dto => dto.Coords, e => e.MapFrom(e => e.Coords))
                .ForMember(dto=> dto.Carriage, e => e.MapFrom(e=>e.Carriage))
                .ForMember(dto => dto.RoutePlate, e=>e.MapFrom(e=>e.Label))
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

                cfg.CreateMap<Carriage, Data.Models.Rails.Carriage>()
                .ForMember(e => e.Id, e => e.Ignore());

                cfg.CreateMap<RoutePlate, Data.Models.Rails.RoutePlate>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Angle, e => e.MapFrom(e => e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(e => e.X))
                .ForMember(e => e.Y, e => e.MapFrom(e => e.Y))
                .ForMember(e => e.Name, e => e.MapFrom(e => e.Name));

                cfg.CreateMap<Park, Data.Models.Stations.Park>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Name, e => e.MapFrom(e => e.Name))
                .ForMember(e => e.ParkId, e => e.MapFrom(e => e.ParkId))
                .ForMember(e => e.Rails, e => e.MapFrom(e => e.Rails))
                .ForMember(e => e.Code, e => e.MapFrom(e => e.Code));

            });
            _mapper = config.CreateMapper();
        }

        public static IMapper GetMapperInstance()
        {
            return _mapper;
        }
            
    }
}
