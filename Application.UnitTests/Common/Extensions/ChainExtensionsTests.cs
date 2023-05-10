using Bogus;
using FluentAssertions;
using GraduationProject.Application.Common.Extensions;

namespace Graduation.Application.UnitTests.Common.Extensions;

public class ChainExtensionsTests
{
    [Fact]
    public void Pipe_ShouldReturnTransformedObject()
    {
        // Arrange
        var faker = new Faker();
        var obj = faker.Random.String();
        var expected = faker.Random.String();
        
        // Act
        var actual = obj.Pipe(_ => expected);
        
        // Assert
        actual.Should().Be(expected);
    }
}
