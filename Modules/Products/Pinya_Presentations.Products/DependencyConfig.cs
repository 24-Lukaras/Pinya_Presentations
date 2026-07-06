using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pinya_Presentations.Products.Database;
using Pinya_Presentations.Products.Features;

namespace Pinya_Presentations.Products;

public static class DependencyConfig
{
    public static IServiceCollection AddProducts(this IServiceCollection services, IConfigurationSection config)
    {
        services.AddDbContext<ProductsDb>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("Default"));
        });
        services.AddTransient<IAddProductHandler, AddProduct>();
        services.AddTransient<IGetBriefProductsHandler, GetBriefProducts>();
        services.AddTransient<IGetProductHandler, GetProduct>();
        services.AddTransient<IAddAmountHandler, AddAmount>();
        return services;
    }
}
