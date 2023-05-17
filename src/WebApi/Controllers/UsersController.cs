using GraduationProject.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

public class UsersController : ApiControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpPost]
    [AllowAnonymous]
    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request, CancellationToken cancellationToken) =>
        await _userService.CreateUser(request, cancellationToken);
}
