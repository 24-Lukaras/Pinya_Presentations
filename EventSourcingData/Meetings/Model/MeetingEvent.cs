namespace EventSourcingData.Meetings;

public class MeetingEvent
{
    public Guid Id { get; }
    public Guid MeetingId { get; }
    public IMeetingEvent Event { get; }
    public DateTime CreatedAtUtc { get; private init; }

    private MeetingEvent(Guid id, Guid meetingId, IMeetingEvent @event, DateTime createdAtUtc)
    {
        Id = id;
        MeetingId = meetingId;
        Event = @event;
        CreatedAtUtc = createdAtUtc;
    }

    public MeetingEvent(Guid meetingId, IMeetingEvent @event)
    {
        Id = Guid.NewGuid();
        MeetingId = meetingId;
        Event = @event;
        CreatedAtUtc = DateTime.UtcNow;
    }
}
