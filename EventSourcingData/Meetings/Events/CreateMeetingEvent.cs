namespace EventSourcingData.Meetings;

public class CreateMeetingEvent : IMeetingEvent
{
    public string Title { get; }
    public CreateMeetingEvent(string title)
    {
        Title = title;
    }

    public void Apply(Meeting meeting)
    {
        meeting.Title = Title;
    }
}
