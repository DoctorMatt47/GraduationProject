using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Common.Exceptions;
using GraduationProject.Application.Identities;
using GraduationProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GraduationProject.Application.Users;

public class UserService : IUserService
{
    private readonly IAppDbContext _dbContext;
    private readonly IIdentityRepository _identities;
    private readonly ILogger<UserService> _logger;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IAuthTokenRepository _tokens;

    public UserService(
        IAppDbContext dbContext,
        IPasswordHashService passwordHashService,
        IIdentityRepository identities,
        IAuthTokenRepository tokens,
        ILogger<UserService> logger)
    {
        _dbContext = dbContext;
        _passwordHashService = passwordHashService;
        _identities = identities;
        _tokens = tokens;
        _logger = logger;
    }

    public async Task<CreateUserResponse> CreateUser(
        CreateUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var userExist = await _dbContext.Set<User>().AnyAsync(u => u.Login == request.Login, cancellationToken);
        if (userExist) throw ConflictException.AlreadyExists(nameof(User), request.Login);

        var passwordSalt = _passwordHashService.GenerateSalt();
        var passwordHash = _passwordHashService.EncodePassword(request.Password, passwordSalt);
        var user = User.Create(request.Login, passwordSalt, passwordHash);

        await _dbContext.Set<User>().AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created user with id '{Id}'", user.Id);

        var identity = _identities.CreateIdentity(user);
        var token = _tokens.GetToken(identity);

        return new CreateUserResponse(token, user.Id);
    }
}
