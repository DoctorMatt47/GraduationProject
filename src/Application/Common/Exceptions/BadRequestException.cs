namespace GraduationProject.Application.Common.Exceptions;

public class BadRequestException : AppExceptionBase
{
    public BadRequestException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }

    public static BadRequestException IncorrectLoginOrPassword => new("Incorrect login or password");
}
