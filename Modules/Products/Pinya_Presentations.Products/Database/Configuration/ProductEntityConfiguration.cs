using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pinya_Presentations.Products.Domain;

namespace Pinya_Presentations.Products.Database.Configuration;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", DbConsts.DB_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        builder.Ignore(x => x.AvailableAmount);
        builder.HasIndex(x => x.CreatedAtUtc);
    }
}
