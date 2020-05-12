using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public class RouteRepository
    {
        public IList<Route> GetById(int id)
        {
            if (id > 0)
            {
                using (AsusDataContext _db = new AsusDataContext())
                {
                    return _db.Routes.Where(e => e.ParkId == id).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code");
            }
        }
    }
}
