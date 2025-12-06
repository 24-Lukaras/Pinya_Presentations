namespace EventSourcingData.Meetings;

public class MeetingNote
{
    public Guid Id { get; }
    public string Content { get; private init; }

    private MeetingNote(Guid id, string content)
    {
        Id = id;
        Content = content;
    }
    public MeetingNote(string content)
    {
        Id = Guid.NewGuid();
        Content = content;
    }
}
