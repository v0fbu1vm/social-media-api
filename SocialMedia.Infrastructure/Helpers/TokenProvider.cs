using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Infrastructure.Helpers
{
    public class TokenProvider : ITokenProvider
    {
        /// <inheritdoc cref="ITokenProvider.GenerateToken(User)"/>
        public Token GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.SecurityKey);
            DateTime expires = DateTime.UtcNow.AddDays(30);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = AppSettings.Issuer,
                Audience = AppSettings.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new Token()
            {
                Content = tokenString,
                ExpirationDate = expires,
            };
        }
    }
}
