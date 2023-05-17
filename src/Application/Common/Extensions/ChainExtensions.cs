namespace GraduationProject.Application.Common.Extensions;

public static class ChainExtensions
{
    public static TResponse Pipe<TRequest, TResponse>(this TRequest obj, Func<TRequest, TResponse> transform) =>
        transform(obj);
}
