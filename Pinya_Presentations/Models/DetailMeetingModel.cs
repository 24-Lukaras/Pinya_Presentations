namespace Pinya_Presentations.Models;

public class DetailMeetingModel
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public bool Editable { get; init; }

    public IReadOnlyList<string> Notes { get; init; } = new List<string>();
    public IReadOnlyList<MeetingEventModel> Events { get; init; } = new List<MeetingEventModel>();
}

public class MeetingEventModel
{
    public string EventName { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public string Author { get; init; } = null!;
}
