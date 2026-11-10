using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pinya_Presentations.Services;

public class MigrationsFactory : BackgroundService, IDesignTimeDbContextFactory<AppDbContext>
{
    private readonly IServiceScopeFactory _scopeFactory;
    public MigrationsFactory(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var factory = scope.ServiceProvider.GetRequiredService<AppDbContextFactory>();
            var tenants = scope.ServiceProvider.GetRequiredService<TenantsService>();
            await factory.ApplyToAllDatabasesAsync(async (db, connectionString) =>
            {
                var pending = await db.Database.GetPendingMigrationsAsync();
                if (pending.Any())
                {
                    await db.Database.MigrateAsync();
                }

                foreach (var tenant in tenants.Tenants)
                {
                    var tenantConnectionString = tenants.GetConnectionString(tenant.Id);
                    if (tenantConnectionString != connectionString)
                        continue;

                    var hasEmployees = await db.Employees.AnyAsync(x => x.TenantId == tenant.Id);
                    if (!hasEmployees)
                    {
                        var faker = new Faker<Employee>()
                            .RuleFor(x => x.Firstname, f => f.Name.FirstName())
                            .RuleFor(x => x.Lastname, f => f.Name.LastName())
                            .RuleFor(x => x.TenantId, tenant.Id)
                            .UseSeed(tenant.Id.GetHashCode());
                        var employees = faker.Generate(10);
                        await db.Employees.AddRangeAsync(employees);
                        await db.SaveChangesAsync();
                    }
                }
            });
        }
    }

    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=localhost;Database=Placeholder;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;
        return new AppDbContext(options);
    }
}
