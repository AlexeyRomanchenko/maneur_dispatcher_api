using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.AuthServer.Scope
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("api", "api")
            };
        public static IEnumerable<Client> Clients =>
           new List<Client>
           {
                 new Client
                {
                    ClientId = "spa-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:4200/account/signin-callback" },
                    AllowedCorsOrigins =     { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200/account/signout-redirect"},
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken=true,
                    AllowOfflineAccess = true,
                    AllowedScopes = {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api"
                    }
                }
           };
}
}
