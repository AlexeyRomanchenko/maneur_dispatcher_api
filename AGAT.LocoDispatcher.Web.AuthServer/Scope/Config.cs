using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.AuthServer.Scope
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("app", "web app")
            };
        public static IEnumerable<Client> Clients =>
           new List<Client>
           {
                new Client
                {
                    ClientId = "webapp",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                     ClientSecrets =
                    {
                        new Secret("Agat_!1s_1T".Sha256())
                    },
                    AllowedScopes = { "app" }
                }
           };
}
}
