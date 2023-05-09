using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Application.Common.Abstractions;

public interface IAppDbContext
{
    public DbSet<T> Set<T>() where T : class;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
