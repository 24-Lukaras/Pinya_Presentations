using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Orders.Domain;
using Pinya_Presentations.Orders.Implementation.Database.Configuration;

namespace Pinya_Presentations.Orders.Implementation.Database;

internal class OrdersDb : DbContext
{
    public OrdersDb(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
    }
}
