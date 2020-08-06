using AGAT.LocoDispatcher.AsusData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<StationPark> GetParkByStationAndCodeAsync(string station, string code)
        {
            using (AsusDataContext context = new AsusDataContext())
            {
                return await context.StationParks.Where(e => e.StationCode == station && e.Code == code).FirstOrDefaultAsync();
            }
        }
    }
}
