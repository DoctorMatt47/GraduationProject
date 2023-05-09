namespace GraduationProject.Application.Users;

public interface IPasswordHashService
{
    byte[] GenerateSalt();
    byte[] Encode(string password, byte[] passwordSalt);
}
