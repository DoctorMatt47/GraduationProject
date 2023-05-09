using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GraduationProject.Application.Users;

public class PasswordHashService : IPasswordHashService
{
    private const int BitCount = 8;
    private const int IterationCount = 100_000;
    private const int SubkeyBitCount = 256;

    public byte[] GenerateSalt()
    {
        var salt = new byte[16];
        RandomNumberGenerator.Create().GetBytes(salt);
        return salt;
    }

    public byte[] EncodePassword(string password, byte[] passwordSalt)
    {
        return KeyDerivation.Pbkdf2(
            password,
            passwordSalt,
            KeyDerivationPrf.HMACSHA256,
            IterationCount,
            SubkeyBitCount / BitCount);
    }
}
