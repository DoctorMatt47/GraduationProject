using System.Security.Claims;
using System.Security.Principal;
using GraduationProject.Application.Identities;
using GraduationProject.Domain.Entities;

namespace GraduationProject.Infrastructure.Identities;

public class IdentityRepository : IIdentityRepository
{
    public IdentityRepository(IPrincipal principal)
    {
        if (principal.Identity?.Name is null) return;
        Current = new IdentityUser(Guid.Parse(principal.Identity.Name));
    }

    public IdentityUser? Current { get; init; }

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
