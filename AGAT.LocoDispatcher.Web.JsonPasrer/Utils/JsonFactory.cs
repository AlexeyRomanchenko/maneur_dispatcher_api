using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using CheckpointEvent = AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels.CheckpointEvent;
using EmergencyEvent = AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels.EmergencyEvent;
using StartMoveEvent = AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels.StartMoveEvent;
using StopMoveEvent = AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels.StopMoveEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class JsonFactory
    {
        public IEvent GetEventFactory(dynamic jsonObject)
        {
            switch (jsonObject.type.ToString())
            {
                case EventConstants.StartMoveEvent:
                    try
                    {
                        StartMoveEvent startEvent = new StartMoveEvent(
                            jsonObject.type.ToString(),
                            (int)jsonObject.timestamp,
                            (int)jsonObject.direction,
                            (int)jsonObject.direction_parity,
                            jsonObject.message.ToString());
                        return startEvent;
                    }

                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.StopMoveEvent:
                    try
                    {
                        StopMoveEvent stopEvent = new StopMoveEvent(
                            jsonObject.type.ToString(),
                            (int)jsonObject.timestamp,
                            (int)jsonObject.distance,
                            jsonObject.checkpoint_number.ToString(),
                            jsonObject.track_number.ToString(),
                            jsonObject.message.ToString()
                            );
                        return stopEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.PassCheckpoint:
                    try
                    {
                        CheckpointEvent checkpointEvent = new CheckpointEvent(
                            jsonObject.type.ToString(),
                            (int)jsonObject.timestamp,
                            jsonObject.train_id.ToString(),
                            (int)jsonObject.speed,
                            jsonObject.checkpoint_number.ToString(),
                            jsonObject.track_number.ToString(),
                            jsonObject.message.ToString()
                            );
                        return checkpointEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.StopOutsideStation:
                    try
                    {
                        StopMoveEvent stopEvent = new StopMoveEvent(
                                jsonObject.type.ToString(),
                                (int)jsonObject.timestamp,
                                (int)jsonObject.distance,
                                jsonObject.checkpoint_number.ToString(),
                                jsonObject.track_number.ToString(),
                                jsonObject.message.ToString()
                                );
                        return stopEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.Emergency:
                    try
                    {
                        EmergencyEvent emergencyEvent = new EmergencyEvent(
                              jsonObject.type.ToString(),
                                (int)jsonObject.timestamp,
                                jsonObject.train_id.ToString(),
                                jsonObject.emergency_type.ToString(),
                                (int)jsonObject.emergency_status,
                                jsonObject.message.ToString());
                        return emergencyEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                default:
                    Console.WriteLine($"Entered DEFAULT{ jsonObject.type.ToString()} ");
                    return null;
            }
        }
    }
}
