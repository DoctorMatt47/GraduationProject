namespace GraduationProject.Application.Common.Exceptions;

public class NotFoundException : ApplicationExceptionBase
{
    public NotFoundException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
