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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(e =>
        {
            e.OwnsMany(x => x.Milestones, milestone =>
            {
                milestone.ToTable("Milestones");
            });
        });
    }
}
