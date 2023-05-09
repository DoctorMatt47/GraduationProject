namespace GraduationProject.Application.Common.Exceptions;

public class BadRequestException : ApplicationExceptionBase
{
    public BadRequestException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
