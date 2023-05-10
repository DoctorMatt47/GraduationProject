using GraduationProject.Application.Identities;
using GraduationProject.Infrastructure.Identities;
using GraduationProject.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject.Infrastructure.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfigurationRoot configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(connectionString));

        services.AddSingleton<IAuthTokenRepository, AuthTokenRepository>();
        services.AddSingleton<IIdentityRepository, IdentityRepository>();
        
        return services;
    }
}