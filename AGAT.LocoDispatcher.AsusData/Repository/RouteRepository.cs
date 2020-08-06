using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public class RouteRepository
    {
        public IList<Route> GetByCode(int parkId, string code)
        {
            if (!string.IsNullOrEmpty(code?.Trim()))
            {
                using (AsusDataContext _db = new AsusDataContext())
                {
                    return _db.Routes.Where(e => e.ParkCode ==code && e.ParkId == parkId).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code");
            }
        }
    }
}
