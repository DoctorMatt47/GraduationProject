using Bogus;
using FluentAssertions;
using GraduationProject.Application.Common.Extensions;
using GraduationProject.Application.Common.Requests;
using GraduationProject.Application.Common.Responses;
using MockQueryable.NSubstitute;

namespace GraduationProject.Application.UnitTests.Common.Extensions;

public class EntityFrameworkExtensionsTests
{
    [Fact]
    public async Task ToPageAsync_ShouldReturnPageResponse()
    {
        // Arrange
        var faker = new Faker();
        var collection = faker.Random.WordsArray(10);
        var queryable = collection.AsQueryable().BuildMock();
        var page = faker.Random.Int(1, 10);
        var pageSize = faker.Random.Int(1, 10);

        // Act
        var result = await queryable.ToPageAsync(new PageRequest(page, pageSize));

        // Assert
        result.Should().BeOfType<PageResponse<string>>();
        result.TotalItems.Should().Be(collection.Length);
        result.TotalPages.Should().Be((int) Math.Ceiling(collection.Length / (double) pageSize));
        result.Items.Should().BeAssignableTo<IEnumerable<string>>();
        result.Items.Should().HaveCountLessOrEqualTo(pageSize);
    }
}
