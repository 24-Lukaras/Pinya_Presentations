using Pinya_Presentations.Db.Entities;

namespace Pinya_Presentations.Services;

public class CategoriesScopedCache
{
    public IReadOnlyList<Category>? Categories { get; set; }
}
