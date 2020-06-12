using AGAT.LocoDispatcher.AsusData.Repository;
using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.RouteModels;
using System;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class CarriageManager
    {
        private CarriageInfoRepository _repository;
        public CarriageManager()
        {
            _repository = new CarriageInfoRepository();
        }
        public IEnumerable<CarriageInfo> GetCarriageInfoByRouteId(int id)
        {
            try
            {
                var info = _repository.GetByRouteId(id);
                IEnumerable<CarriageInfo> result = Mapper.GetMapperInstance().Map<IEnumerable<CarriageInfo>>(info);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
