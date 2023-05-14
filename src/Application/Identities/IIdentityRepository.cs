using System.Security.Claims;
using GraduationProject.Domain.Entities;

namespace GraduationProject.Application.Identities;

public interface IIdentityRepository
{
    public IdentityUser? Current { get; }
    public ClaimsIdentity CreateIdentity(IdentityUser request);
}
