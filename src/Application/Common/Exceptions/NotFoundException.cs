using System.Runtime.CompilerServices;

namespace GraduationProject.Application.Common.Exceptions;

public class NotFoundException : AppExceptionBase
{
    public NotFoundException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }

    public static ConflictException DoesNotExist(
        string entityName,
        object propertyValue,
        [CallerArgumentExpression(nameof(propertyValue))]
        string propertyName = null!) =>
        new($"There is no {entityName} with {propertyName} '{propertyValue}'");
}
