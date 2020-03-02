using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using Microsoft.Data.SqlClient;
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
                catch (SqlException exception)
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
                        return db.Rails.Where(e => e.StationId == id).Include(e => e.Coords).ToList();
                    }
                }
                catch (SqlException exception)
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
