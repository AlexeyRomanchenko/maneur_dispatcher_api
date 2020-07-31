using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Helpers.LogicHelpers
{
    public class LocoShiftHelper
    {
        private DataManager manager;
        public LocoShiftHelper()
        {
            manager = new DataManager();
        }
        public async Task AddLocoShiftAsync(LocoShiftEvent loco, int timestamp)
        {
            try
            {
                if (loco is null)
                {
                    throw new ArgumentNullException("Locomotive number is not valid");
                }
                LocoShiftEvent locoShift = await manager.shiftRepository.GetActiveByNameAsync(loco.TrainNumber);
                if (locoShift is null)
                {
                    LocoShiftEvent shiftEvent = new LocoShiftEvent
                    {
                        CreatedAt = DateTime.Now,
                        ESR = loco.ESR,
                        IsValid = true,
                        StartShift = ConvertHelper.TimestampToDateTime(timestamp),
                        TrainNumber = loco.TrainNumber
                    };
                    await manager.shiftRepository.CreateAsync(shiftEvent);
                }
                else if (!locoShift.IsValid) 
                {
                    locoShift.StartShift = ConvertHelper.TimestampToDateTime(timestamp);
                    locoShift.ESR = loco.ESR;
                    locoShift.IsValid = true;
                    await manager.shiftRepository.UpdateShiftEndAsync(locoShift);
                }
                else
                {
                    locoShift.EndShift = ConvertHelper.TimestampToDateTime(timestamp);
                    await manager.shiftRepository.UpdateShiftEndAsync(locoShift);
                    LocoShiftEvent newShiftEvent = new LocoShiftEvent
                    {
                        CreatedAt = DateTime.Now,
                        ESR = locoShift.ESR + "OK" ,
                        IsValid = true,
                        StartShift = ConvertHelper.TimestampToDateTime(timestamp),
                        TrainNumber = locoShift.TrainNumber
                    };
                    await manager.shiftRepository.CreateAsync(newShiftEvent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
