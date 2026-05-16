using Microsoft.Extensions.DependencyInjection;
using Pinya_Presentations.Modules.Absence.Navigation;
using Pinya_Presentations.Services.Navigation;

namespace Modules.Absences;

public static class DependencyInjection
{
    public static IServiceCollection AddAbsences(this IServiceCollection services)
    {
        services.AddSingleton<ModuleFeatureMarker>();

        services.AddScoped<INavigationItem, AllAbsenceNavigationItem>();
        services.AddScoped<INavigationItem, SubordinatesAbsenceNavigationItem>();
        services.AddScoped<INavigationItem, AbsenceSettingsNavigationItem>();

        return services;
    }
}
