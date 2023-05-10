using System.Text;
using Bogus;
using FluentAssertions;
using GraduationProject.Application.Users;

namespace Graduation.Application.UnitTests.Users;

public class PasswordHashServiceTests
{
    [Fact]
    public void Encode_ShouldReturnHashedPassword()
    {
        // Arrange
        var faker = new Faker();
        var password = faker.Random.String2(10);
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var salt = faker.Random.Bytes(16);
        var passwordHashService = new PasswordHashService();
        
        // Act
        var actual = passwordHashService.EncodePassword(password, salt);
        
        // Assert
        actual.Should().NotBeEquivalentTo(passwordBytes);
    }
}
