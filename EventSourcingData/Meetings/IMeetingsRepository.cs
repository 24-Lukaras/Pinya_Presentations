namespace EventSourcingData.Meetings;

public interface IMeetingsRepository
{
    public Task<Meeting?> GetByIdAsync(Guid id);
    public Task<IReadOnlyList<Meeting>> GetAllAsync();

    public Task<Meeting> CreateNewAsync(string title);
    public Task<Meeting> ApplyEventAsync(Meeting meeting, IMeetingEvent @event); 
}
