using System.Security.Claims;

namespace GraduationProject.Application.Identities;

public interface IAuthTokenRepository
{
    public string GetToken(ClaimsIdentity identity);
}
