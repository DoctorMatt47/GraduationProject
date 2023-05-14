namespace GraduationProject.Domain.Entities;

public class User : IdentityUser
{
    private User() : base(Guid.NewGuid())
    {
    }

    public string Login { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public long MaxBytesAvailable { get; private set; } = 104_857_600;
    public long BytesUsed { get; private set; } = 0;

    public static User Create(string login, byte[] passwordSalt, byte[] passwordHash) =>
        new()
        {
            Login = login,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash,
        };
}
