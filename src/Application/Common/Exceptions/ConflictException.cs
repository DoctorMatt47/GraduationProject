using System.Runtime.CompilerServices;

namespace GraduationProject.Application.Common.Exceptions;

public class ConflictException : AppExceptionBase
{
    public ConflictException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }
    
    public static ConflictException AlreadyExists(
        string entityName,
        object propertyValue,
        [CallerArgumentExpression(nameof(propertyValue))] string propertyName = null!)
    {
        return new ConflictException($"There is already a {entityName} with {propertyName} '{propertyValue}'");
    }
}
