using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pinya_Presentations.Db.ModelConfiguration;

namespace Pinya_Presentations.Db;

public class Database : DbContext
{
    private readonly string _connectionString;
    public Database(IOptions<DatabaseOptions> options)
    {
        _connectionString = options.Value?.ConnectionString ?? throw new NullReferenceException(nameof(DatabaseOptions.ConnectionString));
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeFamilyMember> EmployeeFamilyMembers => Set<EmployeeFamilyMember>();
    public DbSet<Candidate> Candidates => Set<Candidate>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeFamilyMembersConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}
