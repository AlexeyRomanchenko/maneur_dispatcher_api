using AGAT.LocoDispatcher.Data.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class LocomotiveRepository
    {
        public void Create(Locomotive item)
        {
            try
            {
                if (item != null)
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        context.Locomotives.Add(item);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new ArgumentNullException("Ломокотив невалидный");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Locomotive GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        return context.Locomotives.Where(e => e.Id == id).FirstOrDefault();
                    }
                }
                else
                {
                    throw new ArgumentNullException("Не получилось идентифицировать локомотив");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<Locomotive>> GetLocomotives()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                   return await context.Locomotives.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
