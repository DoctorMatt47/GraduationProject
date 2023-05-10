using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GraduationProject.Application.Identities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GraduationProject.Infrastructure.Identities;

public class AuthTokenRepository : IAuthTokenRepository
{
    private readonly AuthOptions _options;

    public AuthTokenRepository(IOptions<AuthOptions> options) => _options = options.Value;

    public string GetToken(ClaimsIdentity identity)
    {
        var jwt = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            identity.Claims,
            DateTime.UtcNow,
            null,
            new SigningCredentials(
                _options.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
