namespace EventSourcingData.Meetings;

public interface IMeetingsRepository
{
    public ValueTask<Meeting?> GetByIdAsync(Guid id);
    public Task<IReadOnlyList<Meeting>> GetAllAsync();

    public Task<Meeting> CreateNewAsync(string title);
    public Task<Meeting> ApplyEventAsync(Meeting meeting, MeetingEventBase @event);
}
