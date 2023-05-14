using System.Reflection;
using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Persistence.Contexts;

public sealed class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
