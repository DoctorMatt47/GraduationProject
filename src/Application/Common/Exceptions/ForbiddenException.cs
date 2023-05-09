namespace GraduationProject.Application.Common.Exceptions;

public class ForbiddenException : ApplicationExceptionBase
{
    public ForbiddenException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
