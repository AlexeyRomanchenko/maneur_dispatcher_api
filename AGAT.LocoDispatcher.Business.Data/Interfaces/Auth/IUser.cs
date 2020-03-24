using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Interfaces.Auth
{
    interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Profession { get; set; }
        string PasswordHash { get; set; }
    }
}
