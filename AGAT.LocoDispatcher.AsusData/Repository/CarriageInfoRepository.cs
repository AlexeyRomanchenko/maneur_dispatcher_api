using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public class CarriageInfoRepository
    {
        public IList<CarriageInfo> GetByRouteId(int routeId)
        {
            try
            {
                using (AsusDataContext context = new AsusDataContext())
                {
                    return context.CarriageInfos.Where(e => e.RouteId == routeId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
