
namespace EventSourcingData.Meetings;

internal class MeetingsRepository : IMeetingsRepository
{
    public Task<Meeting> ApplyEventAsync(Meeting meeting, IMeetingEvent @event)
    {
        throw new NotImplementedException();
    }

    public Task<Meeting> CreateNewAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Meeting>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Meeting?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
