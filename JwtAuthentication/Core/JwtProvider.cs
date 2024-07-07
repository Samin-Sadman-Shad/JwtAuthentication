using JwtAuthentication.Abstraction;
using JwtAuthentication.DataClass;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace JwtAuthentication.Core
{
    internal class JwtProvider : IJwtProvider
    {
        JwtOptions _jwtOptions = null;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        Claim[] claims = new Claim[]
        {

        };

        
            
        string IJwtProvider.Generate(Member member)
        {
            SigningCredentials signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.security_key)),
            SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience, 
                claims,
                null, 
                DateTime.UtcNow.AddHours(1), 
                signingCredentials);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
