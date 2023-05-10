namespace GraduationProject.Application.Common.Responses;

public record PageResponse<T>(
    IEnumerable<T> Items,
    int TotalPages,
    int TotalItems);
