using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace EventSourcingData.Meetings;

internal class EventToJsonConverter : ValueConverter<MeetingEventBase, string>
{
    public EventToJsonConverter() : base(
        @event => ToJson(@event),
        json => FromJson(json),
        null)
    {
    }

    private static string ToJson(MeetingEventBase @event) => JsonSerializer.Serialize(@event);
    private static MeetingEventBase FromJson(string json) => JsonSerializer.Deserialize<MeetingEventBase>(json)!;
}
