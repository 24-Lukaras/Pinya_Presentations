namespace EventSourcingData.Meetings;

public class MeetingEvent
{
    public Guid Id { get; }
    public Guid MeetingId { get; }
    public MeetingEventBase Event { get; }
    public DateTime CreatedAtUtc { get; private init; }
    public string Author { get; private init; }

    private MeetingEvent(Guid id, Guid meetingId, MeetingEventBase @event, DateTime createdAtUtc, string author)
    {
        Id = id;
        MeetingId = meetingId;
        Event = @event;
        CreatedAtUtc = createdAtUtc;
        Author = author;
    }

    public MeetingEvent(Guid meetingId, MeetingEventBase @event, string author)
    {
        Id = Guid.NewGuid();
        MeetingId = meetingId;
        Event = @event;
        CreatedAtUtc = DateTime.UtcNow;
        Author = author;
    }
}
