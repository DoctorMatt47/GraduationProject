namespace GraduationProject.Domain.Exceptions;

public class DomainConflictException : Exception
{
    public DomainConflictException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
}
