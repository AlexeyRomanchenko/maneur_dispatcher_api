using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);
        IEnumerable<T> GetById(int id);
    }
}
