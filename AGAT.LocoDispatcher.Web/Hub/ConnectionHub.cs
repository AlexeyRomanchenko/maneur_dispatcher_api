using AGAT.LocoDispatcher.Business.Classes.Managers;
using AGAT.LocoDispatcher.Business.Models.LocoModels;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web
{
    public class ConnectionHub : Hub
    {
        private LocoManager _locoManager;
        public ConnectionHub()
        {
            _locoManager = new LocoManager();
        }
        public async Task GetLocomotives(string station)
       {
            try
            {
                var locomotives = await _locoManager.GetActiveByStationAsync(station,0);
                await Clients.Caller.SendAsync("Locomotives", locomotives);
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }
    }
}
