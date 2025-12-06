namespace EventSourcingData.Meetings;

public class ArchiveMeetingEvent : IMeetingEvent
{
    public void Apply(Meeting meeting)
    {
        meeting.Status = MeetingStatus.Archived;
    }
}
