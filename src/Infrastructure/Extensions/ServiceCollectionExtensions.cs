using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        return services;
    }
}
