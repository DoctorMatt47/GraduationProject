using Amazon.S3;
using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Files;
using GraduationProject.Application.Identities;
using GraduationProject.Infrastructure.Files;
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

        services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddSingleton<IAuthTokenRepository, AuthTokenRepository>();
        services.AddScoped<IFileRepository, FileS3Repository>();

        services.AddScoped<IIdentityRepository, IdentityRepository>();

        var awsOptions = configuration.GetAWSOptions();
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonS3>();

        return services;
    }
}
