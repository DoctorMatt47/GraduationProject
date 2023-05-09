namespace GraduationProject.Application.Common.Responses;

public record PageResponse<T>(
    IEnumerable<T> Items,
    int PageCount,
    int ItemTotalCount);
