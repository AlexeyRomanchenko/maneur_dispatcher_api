using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public class StationParkRepository : IRepository<StationPark>
    {
        public IList<StationPark> GetByCode(string code)
        {
            if (!String.IsNullOrEmpty(code.Trim()))
            {
                using (AsusDataContext context = new AsusDataContext())
                {
                    return context.Parks.Where(e => e.StationCode == code).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code error");
            }
        }
    }
}
