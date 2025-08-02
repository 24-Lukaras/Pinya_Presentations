using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pinya_Presentations.Db.ModelConfiguration;

internal class EmployeeFamilyMembersConfiguration : IEntityTypeConfiguration<EmployeeFamilyMember>
{
    public void Configure(EntityTypeBuilder<EmployeeFamilyMember> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.Name);

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.EmployeeFamilyMembers)
            .HasForeignKey(x => x.EmployeeId);
    }
}
