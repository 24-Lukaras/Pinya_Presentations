using Microsoft.EntityFrameworkCore;

namespace Pinya_Presentations.Services;

public class AppDbContext : DbContext
{

    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Employee> Employees => Set<Employee>();
}

public class Employee
{
    public Guid Id { get; private init; }
    public Guid TenantId { get; init; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
}
