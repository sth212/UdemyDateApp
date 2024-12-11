using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UdemyDateApi.Interfaces;
using UdemyDateApp.Entities;

namespace UdemyDateApi.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private  SymmetricSecurityKey _key;
        //public TokenService(IConfiguration configuration)
        //{
        //    _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["tokenKey"]));
        //}

        public string CreateToken(AppUser user)
        {
            var tokenKey = configuration["tokenKey"]??throw new Exception("");
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var claims = new List<Claim>
           {
               new (JwtRegisteredClaimNames.NameId, user.Name),
           };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescreptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred,

            };
            var tokenHandler=new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDescreptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
