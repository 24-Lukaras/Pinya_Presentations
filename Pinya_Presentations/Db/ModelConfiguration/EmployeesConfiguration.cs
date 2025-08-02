using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pinya_Presentations.Db.ModelConfiguration;

internal class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasPersonalName(x => x.Name);

        builder.HasMany(x => x.EmployeeFamilyMembers)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);
    }
}
