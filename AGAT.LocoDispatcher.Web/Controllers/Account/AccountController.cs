using AGAT.LocoDispatcher.Web.Filters;
using AGAT.LocoDispatcher.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AGAT.LocoDispatcher.Web.Controllers.Account
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        [HttpGet]
        [Authorize]
        [SimpleActionFilter(38)]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Login([FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ClaimsIdentity identity = GetUserIdentity(user);
            if (identity == null)
            {
                return Unauthorized();
            }
            string encJwt = GenerateToken(identity);
            var response = new
            {
                access_token = encJwt,
                username = identity.Name
            };
            return Ok(response);
        }
      
        [HttpPost]
        public bool Logout()
        {
            return true;
        }

        private string GenerateToken(ClaimsIdentity identity)
        {
            DateTime date = DateTime.Now;
            var jwt = new JwtSecurityToken(
                issuer: Auth.ISSUER,
                audience: Auth.CLIENT,
                notBefore: date,
                claims: identity.Claims,
                expires: date.Add(TimeSpan.FromMinutes(Auth.LIFETIME)),
                signingCredentials: new SigningCredentials(Auth.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetUserIdentity(UserViewModel user)
        {
            UserViewModel usr = new UserViewModel
            {
                Username = "Alexey",
                Password = "Password"
            };
            if (user != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
                    };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            else
            {
                return null;
            }

        }
    }
}