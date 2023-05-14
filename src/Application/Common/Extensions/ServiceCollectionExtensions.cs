using GraduationProject.Application.Files;
using GraduationProject.Application.Identities;
using GraduationProject.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject.Application.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHashService, PasswordHashService>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IFileService, FileService>();
        
        return services;
    }
}
