
using EventSourcingData.Services;

namespace EventSourcingData.Meetings;

internal class MeetingsRepository : IMeetingsRepository
{
    private readonly ManagementDbContext _db;
    private readonly ILoggedUserProvider _userProvider;
    public MeetingsRepository(ManagementDbContext db, ILoggedUserProvider userProvider)
    {
        _db = db;
        _userProvider = userProvider;
    }

    public async Task<Meeting> ApplyEventAsync(Meeting meeting, MeetingEventBase @event)
    {
        if (string.IsNullOrEmpty(_userProvider.Username))
            return meeting;

        @event.Apply(meeting);
        var eventEntry = new MeetingEvent(meeting.Id, @event, _userProvider.Username);
        _db.Meetings_Events.Add(eventEntry);
        _db.Meetings_Projection.Update(meeting);
        await _db.SaveChangesAsync();
        return meeting;
    }

    public async Task<Meeting> CreateNewAsync(string title)
    {
        var meeting = new Meeting();
        _db.Meetings_Projection.Add(meeting);
        await _db.SaveChangesAsync();
        await ApplyEventAsync(meeting, new CreateMeetingEvent(title));
        return meeting;
    }

    public Task<IReadOnlyList<Meeting>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Meeting?> GetByIdAsync(Guid id) => _db.Meetings_Projection.FindAsync(id);
}
