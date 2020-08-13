using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AutoMapper;
using System.Linq;
using Carriage = AGAT.LocoDispatcher.Business.Models.RailsModels.Carriage;
using Point = AGAT.LocoDispatcher.Data.Models.Rails.Point;
using Rail = AGAT.LocoDispatcher.Business.Models.RailsModels.Rail;
using RoutePlate = AGAT.LocoDispatcher.Business.Models.RailsModels.RoutePlate;

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
                cfg.CreateMap<AGAT.LocoDispatcher.Data.Models.EventModels.LocoShiftEvent, Models.LocoModels.Locomotive>().ReverseMap();

                cfg.CreateMap<Data.Models.Rails.Coord, Coords>()
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Y)).ReverseMap();

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
                .ForMember(e => e.Id, e=> e.MapFrom(_e=>_e.Id))
                .ForMember(e => e.Angle , e => e.MapFrom(_e=>_e.Angle));

                cfg.CreateMap<Data.Models.Rails.RoutePlate, RoutePlate>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Y))
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name));

                cfg.CreateMap<Data.Models.Stations.Park, Park>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name))
                .ForMember(e => e.ParkId, e => e.MapFrom(_e => _e.ParkId))
                .ForMember(e => e.Rails, e => e.MapFrom(_e => _e.Rails))
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code));

                cfg.CreateMap<Data.Models.Rails.Point, Business.Models.RailsModels.Point>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.Coord, e => e.MapFrom(_e => GetCoord(_e)));

                cfg.CreateMap<AsusData.Models.CarriageInfo, Business.Models.RouteModels.CarriageInfo>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.RouteId, e => e.MapFrom(_e => _e.RouteId))
                .ForMember(e => e.OwnerCode, e => e.MapFrom(_e => _e.OwnerCode))
                .ForMember(e => e.LoadWeight, e => e.MapFrom(_e => _e.LoadWeight))
                .ForMember(e => e.Order, e => e.MapFrom(_e => _e.Order))
                .ForMember(e => e.DestinationCode, e => e.MapFrom(_e => _e.DestinationCode))
                .ForMember(e => e.Description, e => e.MapFrom(_e => _e.Description));

                cfg.CreateMap<AsusData.Models.Assignment, Business.Models.AssignmentModels.Assignment>().ReverseMap();


                //Mapping data from Business layer to DataLayer 
                cfg.CreateMap<Rail, Data.Models.Rails.Rail>()
                .ForMember(dto => dto.Id, _e => _e.Ignore())
                .ForMember(dto => dto.RailCode, e => e.MapFrom(_e => _e.railCode))
                .ForMember(dto => dto.Coords, e => e.MapFrom(_e => _e.Coords))
                .ForMember(dto=> dto.Carriage, e => e.MapFrom(_e => _e.Carriage))
                .ForMember(dto => dto.RoutePlate, e=>e.MapFrom(_e => _e.Label))
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
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle));

                cfg.CreateMap<RoutePlate, Data.Models.Rails.RoutePlate>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Y))
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name));

                cfg.CreateMap<Park, Data.Models.Stations.Park>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name))
                .ForMember(e => e.ParkId, e => e.MapFrom(_e => _e.ParkId))
                .ForMember(e => e.Rails, e => e.MapFrom(_e => _e.Rails))
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code));

                cfg.CreateMap<Business.Models.RailsModels.Point, Point>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.Coord.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Coord.Y));

            });
            _mapper = config.CreateMapper();
        }

        public static IMapper GetMapperInstance()
        {
            return _mapper;
        }

        private static Coords GetCoord(Data.Models.Rails.Point point)
        {
            Coords coord = new Coords
            { 
                X = point.X,
                Y = point.Y
            };
            return coord;
        }
            
    }
}
