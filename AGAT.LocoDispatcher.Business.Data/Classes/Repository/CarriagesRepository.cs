using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    class CarriagesRepository : IRepository<Carriage>
    {
        public void Create(Carriage carriage)
        {
            if (carriage != null)
            {
                try
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        context.Carriages.Add(carriage);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                     throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("carriage is not valid");
            }    
        }

        public IEnumerable<Carriage> GetById(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        return context.Carriages.Where(e => e.RailId == id).ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("Id is nol valid");
            }            
        }

        public void Update(Carriage carriage)
        {
            if (carriage != null)
            {
                try
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        context.Carriages.Update(carriage);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
