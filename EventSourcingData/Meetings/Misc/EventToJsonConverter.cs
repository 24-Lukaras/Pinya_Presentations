using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace EventSourcingData.Meetings;

internal class EventToJsonConverter : ValueConverter<IMeetingEvent, string>
{
    public EventToJsonConverter() : base(
        @event => ToJson(@event),
        json => FromJson(json),
        null)
    {
    }

    private static string ToJson(IMeetingEvent @event) => JsonSerializer.Serialize(@event);
    private static IMeetingEvent FromJson(string json) => JsonSerializer.Deserialize<IMeetingEvent>(json)!;
}
