using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class PointRepository : IRepository<Point>
    {
        public void Create(Point item)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Points.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        public IEnumerable<Point> GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        return context.Points.Where(e => e.ParkId == id).ToList();
                    }
                }
                else
                {
                    throw new ArgumentNullException("Идентификатор парка невалиден");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
