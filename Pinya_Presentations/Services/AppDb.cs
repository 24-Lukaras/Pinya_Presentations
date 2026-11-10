using Pinya_Presentations.Services.Repositories;

namespace Pinya_Presentations.Services;

public interface IAppDb
{
    IEmployeesRepository Employees { get; }
}
public class AppDb : IAppDb, IDisposable
{
    private readonly AppDbContext? _db;
    public AppDb(
        AppDbContextFactory dbFactory,
        ITenantAccessor tenantAccessor)
    {
        _db = dbFactory.GetDbContext();
        Employees = new EmployeesRepository(_db, tenantAccessor);
    }

    public IEmployeesRepository Employees { get; }

    public void Dispose()
    {
        _db?.Dispose();
    }
}
