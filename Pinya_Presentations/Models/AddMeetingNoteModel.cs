namespace Pinya_Presentations.Models;

public class AddMeetingNoteModel
{
    public Guid MeetingId { get; init; }
    public string Note { get; init; } = null!;
}
