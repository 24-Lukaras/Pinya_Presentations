using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pinya_Presentations.Db.ModelConfiguration;

internal class CandidatesConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.Name);
    }
}
