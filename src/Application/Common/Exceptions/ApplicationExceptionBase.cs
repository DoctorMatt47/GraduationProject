namespace GraduationProject.Application.Common.Exceptions;

public abstract class ApplicationExceptionBase : Exception
{
    protected ApplicationExceptionBase(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
