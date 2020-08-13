using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class RailsRepository: IRepository<Rail>
    {
        public void Create(Rail rail)
        {
            if(rail != null)
            {
                try
                {
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        db.Rails.Add(rail);
                        db.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }               
            }
            else
            {
                throw new ArgumentException("Model should not be null");
            }
        }
        public IEnumerable<Rail> GetById(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        var routes = db.Rails.Where(e => e.ParkId == id).Include(e => e.Coords).Include(e => e.Carriage).Include(e => e.RoutePlate).ToList();
                        return routes;
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Id should be more than null. Now Id is {id}");
            }        
        }
    }
}
