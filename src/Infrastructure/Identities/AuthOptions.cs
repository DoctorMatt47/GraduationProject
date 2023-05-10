using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GraduationProject.Infrastructure.Identities;

public class AuthOptions
{
    public string SecretKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;

    public SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.ASCII.GetBytes(SecretKey));
}
