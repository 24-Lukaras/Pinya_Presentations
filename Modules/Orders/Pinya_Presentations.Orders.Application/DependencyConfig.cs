using Microsoft.Extensions.DependencyInjection;
using Pinya_Presentations.Orders.Application.Managers;

namespace Pinya_Presentations.Orders;

public static class DependencyConfig
{
    public static IServiceCollection AddOrdersApp(this IServiceCollection services)
    {
        services.AddScoped<OrdersManager>();
        return services;
    }
}
