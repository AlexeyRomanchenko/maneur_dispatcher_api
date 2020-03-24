using AGAT.LocoDispatcher.Data.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Auth
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set ; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Profession { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
