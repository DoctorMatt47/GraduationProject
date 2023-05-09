namespace GraduationProject.Application.Users;

public interface IPasswordHashService
{
    byte[] GenerateSalt();
    byte[] EncodePassword(string password, byte[] passwordSalt);
}
