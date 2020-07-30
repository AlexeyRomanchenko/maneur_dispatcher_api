using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Managers
{
    public class DataManager
    {
        public DataManager()
        {
            startEventRepository =new StartEventRepository();
            stopEventRepository = new StopEventRepository();
            checkpointEventRepository = new CheckpointEventRepository();
            emergencyRepository = new EmergencyRepository();
        }
        public StartEventRepository startEventRepository { get; set;  }
        public StopEventRepository stopEventRepository { get; set; }
        public CheckpointEventRepository checkpointEventRepository { get; set; }
        public EmergencyRepository emergencyRepository { get; set; }
    }
}
