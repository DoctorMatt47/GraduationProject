using System.Security.Claims;
using Bogus;
using FluentAssertions;
using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Identities;
using GraduationProject.Application.Users;
using GraduationProject.Domain.Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GraduationProject.Application.UnitTests.Identities;

public class IdentityServiceTests
{
    private readonly IAppDbContext _appDbContext;
    private readonly IIdentityRepository _identityRepository;
    private readonly ILogger<IdentityService> _logger;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IAuthTokenRepository _tokens;

    public IdentityServiceTests()
    {
        _appDbContext = Substitute.For<IAppDbContext>();
        _identityRepository = Substitute.For<IIdentityRepository>();
        _logger = Substitute.For<ILogger<IdentityService>>();
        _passwordHashService = Substitute.For<IPasswordHashService>();
        _tokens = Substitute.For<IAuthTokenRepository>();
    }

    [Fact]
    public async Task CreateIdentity_ShouldReturnUserId()
    {
        // Arrange
        var faker = new Faker();

        var token = faker.Random.String();
        var login = faker.Random.String();
        var passwordHash = faker.Random.Bytes(32);

        var user = User.Create(login, faker.Random.Bytes(32), passwordHash);
        var users = new List<User> {user};
        var userDbContext = Testing.MockDbContext(users);

        _appDbContext.Set<User>().Returns(userDbContext);
        _passwordHashService.EncodePassword(Arg.Any<string>(), Arg.Any<byte[]>()).Returns(passwordHash);
        _tokens.GetToken(Arg.Any<ClaimsIdentity>()).Returns(token);

        var identityService = new IdentityService(
            _appDbContext,
            _identityRepository,
            _logger,
            _passwordHashService,
            _tokens);

        var request = new CreateIdentityRequest(login, faker.Random.String());

        // Act
        var response = await identityService.CreateIdentity(request, CancellationToken.None);

        // Assert
        response.Id.Should().Be(user.Id);
        response.Token.Should().Be(token);
    }
}
