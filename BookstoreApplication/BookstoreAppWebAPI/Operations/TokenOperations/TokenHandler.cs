using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using BookstoreAppWebAPI.Entities;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookstoreAppWebAPI.Operations.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration;
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();

            SymmetricSecurityKey symmetricSecurityKey = 
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            SigningCredentials credentials =
                new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            tokenModel.ExpirationDate = DateTime.Now.AddMinutes(30);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModel.ExpirationDate,
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            tokenModel.AccessToken = handler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
