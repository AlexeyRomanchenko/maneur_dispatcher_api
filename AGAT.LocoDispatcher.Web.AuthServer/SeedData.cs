using AGAT.LocoDispatcher.Web.AuthServer.Data;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.AuthServer
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var alice = userMgr.FindByNameAsync("alexey").Result;
                if (alice == null)
                {
                    alice = new IdentityUser
                    {
                        UserName = "alexey"
                    };
                    var result = userMgr.CreateAsync(alice, "Admin_0589").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(alice, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Alexey"),
                        new Claim(JwtClaimTypes.GivenName, "Alexey"),
                        new Claim(JwtClaimTypes.FamilyName, "Romanchenko"),
                        new Claim(JwtClaimTypes.Email, "romanchenko.oleksii@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Console.WriteLine("user created");
                }
                else
                {
                    Console.WriteLine("user already exists");
                }
            }
        }
    }
}
