namespace GraduationProject.Application.Common.Exceptions;

public class NotFoundException : AppExceptionBase
{
    public NotFoundException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
