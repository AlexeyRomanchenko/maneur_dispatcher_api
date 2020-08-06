using AGAT.LocoDispatcher.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories
{
    public class ShiftRepository
    {
        private DatabaseContext context;
        public ShiftRepository()
        {
            context = new DatabaseContext();
        }
        public async Task<IEnumerable<LocoShiftEvent>> GetActiveByStationAsync(string station)
        {
            try
            {
                return await context.LocoShiftEvents.Where(e=>e.EndShift == null && e.ESR == station).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LocoShiftEvent> GetActiveByNameAsync(string locoNumber)
        {
            try
            {
                return await context.LocoShiftEvents.Where(e => e.EndShift == null && e.TrainNumber == locoNumber).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateAsync(LocoShiftEvent locoShift)
        {
            try
            {
                context.LocoShiftEvents.Add(locoShift);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateShiftEndAsync(LocoShiftEvent _event)
        {
            try
            {
                if (_event is null)
                {
                    throw new ArgumentNullException("input parameters are not valid");
                }
                context.LocoShiftEvents.Update(_event);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
