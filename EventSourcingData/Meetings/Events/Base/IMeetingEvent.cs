using System.Text.Json.Serialization;

namespace EventSourcingData.Meetings;

[JsonDerivedType(typeof(AddMeetingNoteEvent))]
[JsonDerivedType(typeof(ArchiveMeetingEvent))]
[JsonDerivedType(typeof(CreateMeetingEvent))]
[JsonDerivedType(typeof(UpdateMeetingEvent))]
public interface IMeetingEvent
{
    public void Apply(Meeting meeting);
}
