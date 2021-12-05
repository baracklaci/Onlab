using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dnd.Dal.Services
{
    public class TokenService
    {
        public string getToken()
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretSecretKey123"));
            var signingCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
