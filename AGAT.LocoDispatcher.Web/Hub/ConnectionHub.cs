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
        private PointManager _pointManager;
        public ConnectionHub()
        {
            _pointManager = new PointManager();
        }
       
        public override async Task OnConnectedAsync()
        {
            
        }
        public async Task GetLocomotives(int parkId)
       {
            try
            {
                Random rnd = new Random();
                 List<Locomotive> locomotives = new List<Locomotive>
                {
                    new Locomotive
                    {
                        Id = 1,
                        Code = "346",
                        Name = "ВЛ-10",
                        Status = true,
                        Speed = 15
                    },
                        new Locomotive
                    {
                        Id = 1,
                        Code = "125",
                        Name = "ВЛ-10",
                        Status = true,
                        Speed = 15
                    }
                };
                foreach (var loco in locomotives)
                {

                    loco.PointId = rnd.Next(1, 36).ToString();
                    Point point = await _pointManager.GetPointByCode(loco.PointId.ToString());
                    if (point != null)
                    {
                        loco.Coords = point.Coord;
                        loco.Angle = point.Angle;  
                    }                             
                }
                await Clients.Caller.SendAsync("Locomotives", locomotives);
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }
    }
}
