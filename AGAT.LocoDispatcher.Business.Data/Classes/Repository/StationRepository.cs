using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Stations;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class StationRepository : IRepository<Station>
    {
        public void Create(Station station)
        {
            try
            {
                using (DatabaseContext _db = new DatabaseContext())
                {
                _db.Stations.Add(station);
                _db.SaveChanges();
                }

            }
            catch (DbException ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<Station> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Station GetStationById(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (DatabaseContext _db = new DatabaseContext()) 
                    {
                        return _db.Stations.Where(e => e.Id == id).FirstOrDefault();
                    }
                }
                catch (DbException ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("station id is not valid");
            }
        }
    }
}
