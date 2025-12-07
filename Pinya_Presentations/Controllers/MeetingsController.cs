using EventSourcingData.Meetings;
using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Models;
using System.Threading.Tasks;

namespace Pinya_Presentations.Controllers;

public class MeetingsController : Controller
{
    private readonly IMeetingsRepository _repository;
    public MeetingsController(IMeetingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var meetings = await _repository.GetAllAsync();
        var model = meetings.Select(x => new GridMeetingModel()
        {
            Id = x.Id,
            Title = x.Title
        }).ToArray();
        return View(model);
    }

    public ActionResult Create() => View();

    [HttpPost]
    public async Task<ActionResult> Create(CreateMeetingModel model)
    {
        var result = await _repository.CreateNewAsync(model.Title);
        return Redirect($"/Meetings/Edit/{result.Id}");
    }

    public async Task<ActionResult> Edit(Guid id)
    {
        var meeting = await _repository.GetByIdAsync(id);
        if (meeting is null)
            return NotFound();

        var events = await _repository.GetEventsAsync(id);

        var model = new DetailMeetingModel()
        {
            Id = meeting.Id,
            Title = meeting.Title,
            Description = meeting.Description,
            Editable = meeting.Status == MeetingStatus.Active,
            Notes = meeting.Notes.Select(x => x.Content).ToList(),
            Events = events.Select(x => new MeetingEventModel()
            {
                EventName = TranslateEventType(x.Event),
                Author = x.Author,
                CreatedAt = x.CreatedAtUtc
            }).ToList()
        };
        return View(model);
    }
    private string TranslateEventType(MeetingEventBase @event) =>
        @event switch
        {
            CreateMeetingEvent => "vytvořeno",
            UpdateMeetingEvent => "aktualizováno",
            AddMeetingNoteEvent => "přidána poznámka",
            ArchiveMeetingEvent => "archivováno",
            _ => "neznámé"
        };

    [HttpPost]
    public async Task<ActionResult> Edit(EditMeetingModel model)
    {
        var entry = await _repository.GetByIdAsync(model.Id);
        if (entry is null)
            return NotFound();
        if (entry.Status != MeetingStatus.Active)
            return Redirect($"/Meetings/Edit/{model.Id}");

        var @event = new UpdateMeetingEvent(model.Title, model.Description);
        var result = await _repository.ApplyEventAsync(entry, @event);
        return Redirect($"/Meetings/Edit/{result.Id}");
    }

    [HttpPost]
    public async Task<ActionResult> AddNote(AddMeetingNoteModel model)
    {
        var entry = await _repository.GetByIdAsync(model.MeetingId);
        if (entry is null)
            return NotFound();
        if (entry.Status != MeetingStatus.Active)
            return Redirect($"/Meetings/Edit/{model.MeetingId}");

        var @event = new AddMeetingNoteEvent(model.Note);
        var result = await _repository.ApplyEventAsync(entry, @event);
        return Redirect($"/Meetings/Edit/{result.Id}");
    }

    [HttpPost]
    public async Task<ActionResult> Archive(Guid id)
    {
        var entry = await _repository.GetByIdAsync(id);
        if (entry is null)
            return NotFound();
        if (entry.Status != MeetingStatus.Active)
            return Redirect($"/Meetings/Edit/{id}");

        var @event = new ArchiveMeetingEvent();
        var result = await _repository.ApplyEventAsync(entry, @event);
        return Redirect($"/Meetings/Edit/{result.Id}");
    }
}
