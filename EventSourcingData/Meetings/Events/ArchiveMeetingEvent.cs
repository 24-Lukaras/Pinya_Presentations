namespace EventSourcingData.Meetings;

public class ArchiveMeetingEvent : MeetingEventBase
{
    public override void Apply(Meeting meeting)
    {
        meeting.Status = MeetingStatus.Archived;
    }
}
