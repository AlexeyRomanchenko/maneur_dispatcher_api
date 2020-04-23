using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class RoutePlatesRepository : IRepository<RoutePlate>
    {
        public void Create(RoutePlate plate)
        {
            if (plate != null)
            {
                try
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        context.RoutePlates.Add(plate);
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
                throw new ArgumentNullException("route label is not valid");
            }
        }

        public IEnumerable<RoutePlate> GetById(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        return context.RoutePlates.Where(e => e.RailId == id).ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("");
            }
        }
    }
}
