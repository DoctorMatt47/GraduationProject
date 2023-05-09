using GraduationProject.Infrastructure.Persistence.Initializers;

namespace GraduationProject.WebApi.Extensions;

public static class ServiceProviderExtensions
{
    public static void CallEntityInitializers(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var initializers = scope.ServiceProvider.GetServices<IEntityInitializer>();
        foreach (var initializer in initializers) initializer.Initialize();
    }
}
