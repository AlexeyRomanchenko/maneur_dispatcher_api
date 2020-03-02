using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.Interfaces
{
    interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
