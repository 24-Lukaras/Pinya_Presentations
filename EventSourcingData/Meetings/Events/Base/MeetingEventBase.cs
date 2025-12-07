using System.Text.Json.Serialization;

namespace EventSourcingData.Meetings;

[JsonDerivedType(typeof(AddMeetingNoteEvent), nameof(AddMeetingNoteEvent))]
[JsonDerivedType(typeof(ArchiveMeetingEvent), nameof(ArchiveMeetingEvent))]
[JsonDerivedType(typeof(CreateMeetingEvent), nameof(CreateMeetingEvent))]
[JsonDerivedType(typeof(UpdateMeetingEvent), nameof(UpdateMeetingEvent))]
public abstract class MeetingEventBase
{
    public abstract void Apply(Meeting meeting);
}
