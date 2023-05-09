namespace GraduationProject.Application.Common.Exceptions;

public class ConflictException : ApplicationExceptionBase
{
    public ConflictException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
