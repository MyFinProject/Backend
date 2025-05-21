using Api.Interfaces;
using Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key ;


        public TokenService(IConfiguration config) {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateToken(AppUser user)
        {

            var issuer = _config["JWT:Issuer"];
            var audience = _config["JWT:Audience"];

            if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
                throw new ApplicationException("JWT configuration is incomplete");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id ),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }

        public string? DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["JWT:Issuer"],
                ValidAudience = _config["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]))
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

            var NameId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return NameId;
        }
    }
}
