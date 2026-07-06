using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pinya_Presentations.Orders.Web;

public static class DependencyConfig
{
    public static IServiceCollection AddOrders(this IServiceCollection services, IConfigurationSection config)
    {
        services.AddControllersWithViews()
            .AddApplicationPart(typeof(IAssemblyMarker).Assembly);
        services.AddOrdersApp();
        services.AddOrdersImplementation(config);
        return services;
    }
}
internal interface IAssemblyMarker;
