namespace GraduationProject.Application.Users;

public record CreateUserResponse(
    string Token,
    Guid Id,
    long MaxBytesAvailable,
    long BytesUsed);

public record CreateUserRequest(
    string Login,
    string Password);
