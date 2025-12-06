namespace EventSourcingData.Meetings;

public class UpdateMeetingEvent
{
    public string Title { get; }
    public string Description { get; }
    public UpdateMeetingEvent(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public void Apply(Meeting meeting)
    {
        meeting.Title = Title;
        meeting.Description = Description;
    }
}
