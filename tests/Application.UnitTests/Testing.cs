using MockQueryable.NSubstitute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NSubstitute;

namespace GraduationProject.Application.UnitTests;

public static class Testing
{
    public static DbSet<T> MockDbContext<T>(List<T> list) where T : class
    {
        var dbSet = list.AsQueryable().BuildMockDbSet();
        
        dbSet.Add(Arg.Any<T>())
            .Returns(_ => null!)
            .AndDoes(x => list.Add(x.Arg<T>()));
        
        dbSet.AddAsync(Arg.Any<T>())
            .Returns(new ValueTask<EntityEntry<T>>((EntityEntry<T>)null!))
            .AndDoes(x => list.Add(x.Arg<T>()));
        
        dbSet.Remove(Arg.Any<T>())
            .Returns(_ => null!)
            .AndDoes(x => list.Remove(x.Arg<T>()));
    
        return dbSet;
    }
}
