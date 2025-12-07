namespace EventSourcingData.Meetings;

public class CreateMeetingEvent : MeetingEventBase
{
    public string Title { get; }
    public CreateMeetingEvent(string title)
    {
        Title = title;
    }

    public override void Apply(Meeting meeting)
    {
        meeting.Title = Title;
    }
}
