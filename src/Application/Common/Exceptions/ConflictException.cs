namespace GraduationProject.Application.Common.Exceptions;

public class ConflictException : AppExceptionBase
{
    public ConflictException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
