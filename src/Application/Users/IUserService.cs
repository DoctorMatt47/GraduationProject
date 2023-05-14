namespace GraduationProject.Application.Users;

public interface IUserService
{
    Task<CreateUserResponse> CreateUser(
        CreateUserRequest request,
        CancellationToken cancellationToken = default);
}
