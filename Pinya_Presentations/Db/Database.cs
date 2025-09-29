using Bogus;
using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db.Entities;

namespace Pinya_Presentations.Db;

public class Database : DbContext
{
    public DbSet<Category> Categories { get; init; }
    public DbSet<Product> Products { get; init; }

    public Database(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(m =>
        {
            m.HasKey(x => x.Id)
                .IsClustered();
        });

        modelBuilder.Entity<Product>(m =>
        {
            m.HasKey(x => x.Id)
                .IsClustered();
        });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((db, seed) =>
        {
            var categories = db.Set<Category>();
            if (!categories.Any())
                SeedCategories(db, categories);
            var products = db.Set<Product>();
            if (!products.Any())
            {
                var categoryIds = categories.Select(x => x.Id).ToArray();
                SeedProducts(db, products, categoryIds);
            }

        });
        base.OnConfiguring(optionsBuilder);
    }

    private void SeedCategories(DbContext db, DbSet<Category> set)
    {
        var faker = new Faker<Category>()
            .RuleFor(x => x.Title, f => f.Commerce.Categories(1)[0])
            .UseSeed(69);
        var categories = faker.Generate(100).ToArray();
        HashSet<string> added = new HashSet<string>();
        foreach (var category in categories)
        {
            if (added.Contains(category.Title))
                continue;

            added.Add(category.Title);
            set.Add(category);
        }
        db.SaveChanges();
    }
    private void SeedProducts(DbContext db, DbSet<Product> set, Guid[] categoryIds)
    {
        var faker = new Faker<Product>()
            .RuleFor(x => x.Title, f => f.Commerce.Product())
            .RuleFor(x => x.CategoryId, f => f.PickRandom(categoryIds))
            .UseSeed(69);
        for (var i = 0; i < 50; i++)
        {
            var product = faker.Generate();
            set.Add(product);
        }
        db.SaveChanges();
    }
}
