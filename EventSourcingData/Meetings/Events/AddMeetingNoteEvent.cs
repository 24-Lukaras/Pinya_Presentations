namespace EventSourcingData.Meetings;

public class AddMeetingNoteEvent : MeetingEventBase
{
    public string Content { get; }
    public AddMeetingNoteEvent(string content)
    {
        Content = content;
    }

    public override void Apply(Meeting meeting)
    {
        var note = new MeetingNote(Content);
        meeting.NotesInternal.Add(note);
    }
}
