using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlintSoft.CRM.Application.Common.Interfaces.Authentication;
using FlintSoft.CRM.Application.Common.Interfaces.Services;
using FlintSoft.CRM.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlintSoft.CRM.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        var jwtSettings = jwtOptions.Value;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret ?? "")),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)
        };

        var secToken = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes ?? 0));

        return new JwtSecurityTokenHandler().WriteToken(secToken);
    }
}
