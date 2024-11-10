using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalBloggingPlatform.Infrastructure.Configuration;
using PersonalBloggingPlatform.Shared.Abstractions.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PersonalBloggingPlatform.Infrastructure.Auth;

public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string GenerateJwtToken(Guid userId, IEnumerable<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);

        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString())
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = _jwtOptions.Audience,
            Issuer = _jwtOptions.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
