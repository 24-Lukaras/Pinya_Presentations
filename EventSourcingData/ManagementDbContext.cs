using EventSourcingData.Meetings;
using Microsoft.EntityFrameworkCore;

namespace EventSourcingData;

internal class ManagementDbContext : DbContext
{
    public ManagementDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ManagementDbContext()
    {
    }

    public virtual DbSet<Meeting> Meetings_Projection => Set<Meeting>();
    public virtual DbSet<MeetingEvent> Meetings_Events => Set<MeetingEvent>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Meeting>(e =>
        {
            e.HasKey(x => x.Id);
            e.OwnsMany(x => x.NotesInternal, y =>
            {
                y.HasKey(x => x.Id);
                y.WithOwner().HasForeignKey("MeetingId");
                y.ToTable(nameof(Meeting.Notes));
            });
            e.HasMany(x => x.EventsInternal)
            .WithOne()
            .HasForeignKey(x => x.MeetingId);
            e.Ignore(x => x.Notes);
            e.Ignore(x => x.Events);
        });
        model.Entity<MeetingEvent>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Event).HasConversion(new EventToJsonConverter());
            e.ToTable(nameof(Meetings_Events));
        });

        base.OnModelCreating(model);
    }
}
