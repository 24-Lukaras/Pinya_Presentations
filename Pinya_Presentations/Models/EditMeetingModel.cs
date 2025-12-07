namespace Pinya_Presentations.Models;

public class EditMeetingModel
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
}
