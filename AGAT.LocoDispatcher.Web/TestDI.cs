using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web
{
    public class TestDI
    {
        public object Make()
        {
            var json = new {
                Name = "Alex",
                Lastname = "Romanchenko",
            };
            return json;
        }
    }
}
