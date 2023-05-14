namespace GraduationProject.Application.Users;

public record CreateUserResponse(
    string Token,
    Guid Id);

public record CreateUserRequest(
    string Login,
    string Password);
