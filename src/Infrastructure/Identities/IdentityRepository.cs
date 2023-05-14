using System.Security.Claims;
using GraduationProject.Application.Identities;
using GraduationProject.Domain.Entities;

namespace GraduationProject.Infrastructure.Identities;

public class IdentityRepository : IIdentityRepository
{
    public ClaimsIdentity CreateIdentity(IdentityUser request)
    {
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, request.Id.ToString()),
        };

        var identity = new ClaimsIdentity(
            claims,
            "Token",
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        return identity;
    }
}
