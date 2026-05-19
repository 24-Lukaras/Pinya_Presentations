using Microsoft.Extensions.DependencyInjection;
using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddNavigationFromAssembly<T>(this IServiceCollection services)
    {
        var assembly = typeof(T).Assembly;

        var navigationItemType = typeof(INavigationItem);
        var classes = assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract);
        foreach (var @class in classes)
        {
            if (@class.GetInterfaces().Any(x => x == navigationItemType))
                services.AddScoped(navigationItemType, @class);
        }

        return services;
    }
}
