using System.Security.Claims;
using Bogus;
using FluentAssertions;
using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Identities;
using GraduationProject.Application.Users;
using GraduationProject.Domain.Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;
namespace GraduationProject.Application.UnitTests.Users;

public class UserServiceTests
{
    private readonly IAppDbContext _appDbContext;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IIdentityRepository _identityRepository;
    private readonly IAuthTokenRepository _authTokenRepository;
    private readonly ILogger<UserService> _logger;

    public UserServiceTests()
    {
        _appDbContext = Substitute.For<IAppDbContext>();
        _passwordHashService = Substitute.For<IPasswordHashService>();
        _identityRepository = Substitute.For<IIdentityRepository>();
        _authTokenRepository = Substitute.For<IAuthTokenRepository>();
        _logger = Substitute.For<ILogger<UserService>>();
    }

    [Fact]
    public async Task CreateUser_ShouldAddUserToDbContext()
    {
        // Arrange
        var faker = new Faker();

        var token = faker.Random.String();
        var users = new List<User>();
        var userDbSet = Testing.MockDbContext(users);
        
        _appDbContext.Set<User>().Returns(userDbSet);
        _authTokenRepository.GetToken(Arg.Any<ClaimsIdentity>()).Returns(token);
        
        var userService = new UserService(
            _appDbContext,
            _passwordHashService,
            _identityRepository,
            _authTokenRepository,
            _logger);

        var request = new CreateUserRequest(faker.Random.String(), faker.Random.String());

        // Act
        var response = await userService.CreateUser(request);

        // Assert
        users.Should().Contain(u => u.Login == request.Login && u.Id == response.Id);
        response.Token.Should().Be(token);
    }
}
