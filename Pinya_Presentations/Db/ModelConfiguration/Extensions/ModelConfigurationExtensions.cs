using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Pinya_Presentations.Db.ModelConfiguration;

internal static class ModelConfigurationExtensions
{
    public static EntityTypeBuilder<T> HasPersonalName<T>(this EntityTypeBuilder<T> entity,
        Expression<Func<T, PersonalName?>> expression)
        where T : class
    {
        entity.OwnsOne(expression, name =>
        {
            name.WithOwner();

            name.Property(x => x.Degrees)
                .HasMaxLength(64);

            name.Ignore(x => x.FullName);
            name.Ignore(x => x.ListName);
        });
        return entity;
    }

}
