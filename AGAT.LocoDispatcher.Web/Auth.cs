using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web
{
    public class Auth
    {
        public const string ISSUER = "AgatToken";
        public const string CLIENT = "FrontendApp";
        public const string KEY = "Agat_1s_Very_0ld1";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
