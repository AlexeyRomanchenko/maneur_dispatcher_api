using AGAT.LocoDispatcher.Data.Models.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Data
{
    public static class Init
    {
        public static void InitData()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (!context.Stations.Any())
                {
                    context.Stations.Add(new Station
                    {
                        Name = "Степянка",
                        Parks = new List<Park> 
                        {
                        new Park{Name = "Парк 1", Code = "01", ParkId = 484 },
                        new Park{Name = "Парк ГС", Code = "ГС", ParkId = 483 },
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
