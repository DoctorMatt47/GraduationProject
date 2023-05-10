namespace GraduationProject.Application.Common.Exceptions;

public abstract class AppExceptionBase : Exception
{
    protected AppExceptionBase(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
