using Bogus;
using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db.Model;

namespace Pinya_Presentations.Db;

public class MigDb : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public MigDb(DbContextOptions options) : base(options)
    {        
    }
}
