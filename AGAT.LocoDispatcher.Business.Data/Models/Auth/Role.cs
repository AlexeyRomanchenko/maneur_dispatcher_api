using AGAT.LocoDispatcher.Data.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Models.Auth
{
    public class Role : IRole
    {
        public int Id { get; set; }
        public string Name {get;set;} 
        public List<User> Users { get; set; }
    }
}
