using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BlazorStore.Server.Helpers
{
    public class TokenHelper
    {
        private readonly byte[] secretKey;
        public TokenHelper(byte[] secretkey)
        {
            this.secretKey = secretkey;
        }

        public string GenerateToken(string userName, string userId)
        {
            DateTime utcNow = DateTime.UtcNow;

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.UserData, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            DateTime expiredDateTime = utcNow.AddDays(5);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            SymmetricSecurityKey symmetric = new SymmetricSecurityKey(secretKey);

            var signingCredentials = new SigningCredentials(symmetric, SecurityAlgorithms.HmacSha256);

            return jwtSecurityTokenHandler.WriteToken(new JwtSecurityToken(claims: claims, expires: expiredDateTime, notBefore: utcNow, signingCredentials: signingCredentials));

        }
    }
}