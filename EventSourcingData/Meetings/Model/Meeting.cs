namespace EventSourcingData.Meetings;

public class Meeting
{

    public Guid Id { get; private init; }

    public string Title { get; internal set; }

    public string Description { get; internal set; }

    public MeetingStatus Status { get; internal set; }
    public IEnumerable<MeetingNote> Notes => NotesInternal;
    public IEnumerable<MeetingEvent> Events => EventsInternal;

    internal ICollection<MeetingNote> NotesInternal { get; private set; } = new HashSet<MeetingNote>();
    internal ICollection<MeetingEvent> EventsInternal { get; private set; } = new HashSet<MeetingEvent>();


    private Meeting(Guid id, string title, string description, MeetingStatus status)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
    }
    public Meeting()
    {
        Id = Guid.NewGuid();
        Title = string.Empty;
        Description = string.Empty;
        Status = MeetingStatus.Active;
    }
}
