namespace GraduationProject.Application.Common.Exceptions;

public class ForbiddenException : AppExceptionBase
{
    public ForbiddenException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
