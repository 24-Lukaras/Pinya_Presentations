using EventSourcingData.Meetings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingData;

public static class DependencyConfig
{
    public static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ManagementDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IMeetingsRepository, MeetingsRepository>();
        return services;
    }
}
