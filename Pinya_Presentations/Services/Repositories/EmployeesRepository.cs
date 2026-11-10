using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Models;

namespace Pinya_Presentations.Services.Repositories;

public interface IEmployeesRepository
{
    Task<IReadOnlyCollection<EmployeeModel>> GetAllAsync();
}
public class EmployeesRepository : IEmployeesRepository
{
    private readonly AppDbContext? _db;
    private readonly ITenantAccessor _tenantAccessor;
    public EmployeesRepository(
        AppDbContext? db,
        ITenantAccessor tenantAccessor)
    {
        _db = db;
        _tenantAccessor = tenantAccessor;
    }
    public async Task<IReadOnlyCollection<EmployeeModel>> GetAllAsync()
    {
        if (_db is null)
            return Array.Empty<EmployeeModel>();
        if (!_tenantAccessor.TenantId.HasValue)
            return Array.Empty<EmployeeModel>();

        var entries = await _db.Employees
            .AsNoTracking()
            .Where(x => x.TenantId == _tenantAccessor.TenantId)
            .ToArrayAsync();

        return entries.Select(x => new EmployeeModel()
        {
            Firstname = x.Firstname,
            Lastname = x.Lastname,
        }).ToArray();
    }
}
