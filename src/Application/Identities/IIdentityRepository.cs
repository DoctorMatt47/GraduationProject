using System.Security.Claims;
using GraduationProject.Domain.Entities;

namespace GraduationProject.Application.Identities;

public interface IIdentityRepository
{
    public ClaimsIdentity CreateIdentity(IdentityUser request);
}
