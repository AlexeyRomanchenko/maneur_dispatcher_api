using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.LocoModels;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class LocoManager
    {
        private ShiftRepository repository;
        private BaseEventRepository baseEventRepository;
        private PointManager pointManager;
        public LocoManager()
        {
            repository = new ShiftRepository();
            baseEventRepository = new BaseEventRepository();
            pointManager = new PointManager();
        }

        public async Task<IEnumerable<LocomotiveViewModel>> GetActiveByStationAsync(string station)
        {
            try
            {
                List<LocomotiveViewModel> locomotives = new List<LocomotiveViewModel>();
                IEnumerable<LocoShiftEvent> locoShifts = await repository.GetActiveByStationAsync(station);
                foreach (var loco in locoShifts)
                {
                    MoveEventBase _event = await GetLastPointAsync(loco.Id);
                    if (string.IsNullOrEmpty(_event?.CheckPointNumber.Trim()))
                    {
                        break;
                    }
                    LocomotiveViewModel locomotive = new LocomotiveViewModel
                    {
                        Id = loco.Id,
                        ESR = loco.ESR,
                        PointId = _event.CheckPointNumber
                    };
                    if (_event != null)
                    {
                        //_event.CheckPointNumber
                        Point point = await pointManager.GetPointByCode(_event.CheckPointNumber);
                        if (point != null)
                        {
                            locomotive.Coords = point.Coord;
                            locomotives.Add(locomotive);
                        }

                    }
                }

                return locomotives;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private async Task<MoveEventBase> GetLastPointAsync(int locoShiftId)
        {
           return await baseEventRepository.GetLastEventByShiftIdAsync(locoShiftId);
        }

    }
}
