using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public interface IRepository<T>
    {
        IList<T> GetByCode(string code);
    }
}
