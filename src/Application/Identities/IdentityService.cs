using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Common.Exceptions;
using GraduationProject.Application.Users;
using GraduationProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GraduationProject.Application.Identities;

public class IdentityService : IIdentityService
{
    private readonly IAppDbContext _dbContext;
    private readonly IIdentityRepository _identities;
    private readonly ILogger<IdentityService> _logger;
    private readonly IPasswordHashService _passwordHash;
    private readonly IAuthTokenRepository _tokens;

    public IdentityService(
        IAppDbContext dbContext,
        IIdentityRepository identities,
        ILogger<IdentityService> logger,
        IPasswordHashService passwordHash,
        IAuthTokenRepository tokens)
    {
        _dbContext = dbContext;
        _identities = identities;
        _logger = logger;
        _passwordHash = passwordHash;
        _tokens = tokens;
    }

    public async Task<IdentityResponse> CreateIdentity(
        CreateIdentityRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Login == request.Login, cancellationToken)
            ?? throw BadRequestException.IncorrectLoginOrPassword;

        var passwordHash = _passwordHash.EncodePassword(request.Password, user.PasswordSalt);

        var hashEquals = user.PasswordHash.SequenceEqual(passwordHash);
        if (!hashEquals) throw BadRequestException.IncorrectLoginOrPassword;

        _logger.LogInformation("Authenticated user with id: {Id}", user.Id);

        var identity = _identities.CreateIdentity(user);
        var token = _tokens.GetToken(identity);

        return new IdentityResponse(token, user.Id);
    }
}
