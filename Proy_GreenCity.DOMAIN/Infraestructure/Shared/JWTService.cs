using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using Proy_GreenCity.DOMAIN.Core.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Infraestructure.Shared
{
    public class JWTService : IJWTService
    {
        public JWTSettings _settings { get; }
        public JWTService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJWToken(Usuarios user)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[] {
                    new Claim(ClaimTypes.Name, (user.Nombre)),
                    new Claim(ClaimTypes.GivenName, user.Nombre),
                    new Claim(ClaimTypes.Email, user.Email),
                   // new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString()),
                    //new Claim(ClaimTypes.Country, user.Country),
                    new Claim(ClaimTypes.Role, user.RolId == 1 ? "Admin": "User"),
                    new Claim("UserId",user.Id.ToString()),
                };

            var payload = new JwtPayload(
                            _settings.Issuer
                            , _settings.Audience
                            , claims
                            , DateTime.UtcNow
                            , DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
