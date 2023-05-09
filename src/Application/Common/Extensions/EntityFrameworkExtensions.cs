using GraduationProject.Application.Common.Requests;
using GraduationProject.Application.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Application.Common.Extensions;

public static class EntityFrameworkExtensions
{
    public static async Task<PageResponse<T>> ToPageAsync<T>(
        this IQueryable<T> collection,
        PageRequest request,
        CancellationToken cancellationToken = default)
    {
        var itemTotalCount = await collection.CountAsync(cancellationToken);
        var pageCount = (int) Math.Ceiling(itemTotalCount / (float) request.Size);
        var items = await collection
            .Skip((request.Number - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(cancellationToken);

        return new PageResponse<T>(items, pageCount, itemTotalCount);
    }
    
}
