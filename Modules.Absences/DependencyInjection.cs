using Microsoft.Extensions.DependencyInjection;
using Pinya_Presentations.Shared;

namespace Modules.Absences;

public static class DependencyInjection
{
    public static IServiceCollection AddAbsences(this IServiceCollection services)
    {
        services.AddSingleton<ModuleFeatureMarker>();

        services.AddNavigationFromAssembly<IAssemblyMarker>();

        return services;
    }
}
