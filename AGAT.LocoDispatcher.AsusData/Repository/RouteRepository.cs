using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public class RouteRepository : IRepository<Route>
    {
        public IList<Route> GetByCode(string code)
        {
            if (!String.IsNullOrWhiteSpace(code))
            {
                using (AsusDataContext _db = new AsusDataContext())
                {
                    return _db.Routes.Where(e => e.ParkCode == code).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code");
            }
        }
    }
}
