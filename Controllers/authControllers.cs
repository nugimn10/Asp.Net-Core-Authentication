using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.Net_core_auth_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Asp.Net_core_auth_task
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate(Auth auth)
        {
            var auths = new List<Auth>()
            {
                new Auth() { Username="nugi", Password="aaaa"},
                new Auth() { Username="nugi2", Password="aaaa"}
            };

            var _auth = auths.Find(e => e.Username == auth.Username);

            var tokenHandler = new JwtSecurityTokenHandler();
            
             var tokenDescription = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, _auth.Username),
                    new Claim(ClaimTypes.Name, _auth.Password)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("")), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenResponse = new
            {
                token = tokenHandler.WriteToken(token),
                auth = _auth.Username
            };

            return Ok(tokenResponse);
        }
    }
}