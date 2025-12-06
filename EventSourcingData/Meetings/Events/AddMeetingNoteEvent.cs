namespace EventSourcingData.Meetings;

public class AddMeetingNoteEvent : IMeetingEvent
{
    public string Content { get; }
    public AddMeetingNoteEvent(string content)
    {
        Content = content;
    }

    public void Apply(Meeting meeting)
    {
        var note = new MeetingNote(Content);
        meeting.NotesInternal.Add(note);
    }
}
