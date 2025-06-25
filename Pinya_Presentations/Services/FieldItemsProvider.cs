using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pinya_Presentations.Services;

public class FieldItemsProvider
{
    private Dictionary<FieldType, IEnumerable<SelectListItem>>? _cache;
    private readonly FieldsService _service;
    public FieldItemsProvider(FieldsService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<SelectListItem>> GetFields(FieldType type)
    {
        if (_cache is null)
        {
            var fields = await _service.GetFields();

            _cache = fields.GroupBy(x => x.Type)
                .ToDictionary(x => x.Key,
                x => x.Select(y => new SelectListItem(y.Title, y.Id.ToString())).ToList().AsEnumerable());
        }

        if (_cache.TryGetValue(type, out var items))
            return items;

        return Array.Empty<SelectListItem>();
    }
}
