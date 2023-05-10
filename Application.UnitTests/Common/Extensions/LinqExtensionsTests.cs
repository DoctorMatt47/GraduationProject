using System.Linq.Expressions;
using Bogus;
using FluentAssertions;
using GraduationProject.Application.Common.Extensions;

namespace Graduation.Application.UnitTests.Common.Extensions;

public class LinqExtensionsTests
{
    [Fact]
    public void WhereIf_ShouldReturnFilteredCollection()
    {
        // Arrange
        var faker = new Faker();
        var collection = faker.Random.WordsArray(10);
        var condition = faker.Random.Bool();
        
        bool Predicate(string x) => x.Length > 5;

        // Act
        var result = collection.WhereIf(condition, Predicate).ToList();

        // Assert
        result.Should().BeAssignableTo<IEnumerable<string>>();
        result.Should().HaveCount(condition ? collection.Count(Predicate) : collection.Length);
    }
    
    [Fact]
    public void WhereIf_ShouldReturnFilteredQueryable()
    {
        // Arrange
        var faker = new Faker();
        var collection = faker.Random.WordsArray(10);
        var queryable = collection.AsQueryable();
        var condition = faker.Random.Bool();
        
        Expression<Func<string, bool>> Predicate() => x => x.Length > 5;

        // Act
        var result = queryable.WhereIf(condition, Predicate());

        // Assert
        result.Should().BeAssignableTo<IQueryable<string>>();
        result.Should().HaveCount(condition ? collection.Count(Predicate().Compile()) : collection.Length);
    }
}
