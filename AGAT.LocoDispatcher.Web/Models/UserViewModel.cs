using AGAT.LocoDispatcher.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.Models
{
    public class UserViewModel : IUser
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="Не указан логин пользователя")]
        public string Username { get; set; }
        //[Required(ErrorMessage = "Не указан пароль пользователя")]
        public string Password { get; set; }
    }
}
