namespace EventSourcingData.Meetings;

public class UpdateMeetingEvent : MeetingEventBase
{
    public string Title { get; }
    public string Description { get; }
    public UpdateMeetingEvent(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public override void Apply(Meeting meeting)
    {
        meeting.Title = Title;
        meeting.Description = Description;
    }
}
