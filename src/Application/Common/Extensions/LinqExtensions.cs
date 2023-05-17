using System.Linq.Expressions;

namespace GraduationProject.Application.Common.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<T> WhereIf<T>(
        this IEnumerable<T> collection,
        bool condition,
        Func<T, bool> predicate) =>
        condition ? collection.Where(predicate) : collection;

    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> collection,
        bool condition,
        Expression<Func<T, bool>> predicate) =>
        condition ? collection.Where(predicate) : collection;
}
