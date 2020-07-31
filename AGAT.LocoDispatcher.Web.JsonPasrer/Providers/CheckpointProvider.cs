﻿using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using System;
using System.Threading.Tasks;
using CheckpointModel = AGAT.LocoDispatcher.Data.Models.EventModels.CheckpointEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class CheckpointProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper helper;
        public CheckpointProvider()
        {
            _manager = new DataManager();
            helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                CheckpointEvent checkpointEvent = (CheckpointEvent)_event;
                int shiftId = await helper.GetLocoShiftIdByLocoNumber(checkpointEvent.TrainId);
                CheckpointModel checkpoint = new CheckpointModel
                {
                    Type = checkpointEvent.Type,
                    CheckPointNumber = checkpointEvent.CheckPointNumber,
                    Message = checkpointEvent.Message,
                    Speed = checkpointEvent.Speed,
                    ShiftId = shiftId,
                    Timestamp = checkpointEvent.Timestamp,
                    TrackNumber = checkpointEvent.TrackNumber
                };
                await _manager.checkpointEventRepository.CreatAsync(checkpoint);
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
