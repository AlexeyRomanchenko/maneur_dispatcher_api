using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Interfaces.Auth
{
    interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
