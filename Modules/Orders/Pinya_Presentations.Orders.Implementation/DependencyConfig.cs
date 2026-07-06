using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pinya_Presentations.Orders.Application.Data;
using Pinya_Presentations.Orders.Implementation.Database;
using Pinya_Presentations.Orders.Implementation.Database.Repositories;

namespace Pinya_Presentations.Orders;

public static class DependencyConfig
{
    public static IServiceCollection AddOrdersImplementation(this IServiceCollection services, IConfigurationSection config)
    {
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        services.AddDbContext<OrdersDb>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("Default"));
        });
        return services;
    }
}
