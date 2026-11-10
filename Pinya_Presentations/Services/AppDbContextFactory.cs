using Microsoft.EntityFrameworkCore;

namespace Pinya_Presentations.Services;

public class AppDbContextFactory
{
    private readonly TenantsService _service;
    private readonly ITenantAccessor _accessor;
    public AppDbContextFactory(
        TenantsService service,
        ITenantAccessor tenantAccessor)
    {
        _service = service;
        _accessor = tenantAccessor;
    }

    public AppDbContext? GetDbContext()
    {
        if (!_accessor.TenantId.HasValue)
            return null;

        var connectionString = _service.GetConnectionString(_accessor.TenantId.Value);
        if (connectionString is null)
            return null;

        var options =
            new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

        return new AppDbContext(options);
    }

    public async Task ApplyToAllDatabasesAsync(Func<AppDbContext, string, Task> action)
    {
        var connectionStrings = _service.GetAllConnectionStrings();

        List<(AppDbContext, string)> databases = new();
        foreach (var connectionString in connectionStrings) 
        {
            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(connectionString)
                    .Options;

            var db =  new AppDbContext(options);
            databases.Add((db, connectionString));
        }

        List<Task> tasks = databases.Select((x, i) => action(x.Item1, x.Item2)).ToList();
        await Task.WhenAll(tasks);
        foreach (var db in databases)
            await db.Item1.DisposeAsync();
    }

}
