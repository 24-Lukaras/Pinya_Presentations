using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Products.Database.Configuration;
using Pinya_Presentations.Products.Domain;

namespace Pinya_Presentations.Products.Database;

internal class ProductsDb : DbContext
{
    public ProductsDb(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
