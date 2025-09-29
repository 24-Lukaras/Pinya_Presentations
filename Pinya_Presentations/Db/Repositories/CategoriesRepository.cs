using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db.Entities;
using Pinya_Presentations.Services;

namespace Pinya_Presentations.Db.Repositories;

public class CategoriesRepository
{
    private readonly Database _db;
    private readonly CategoriesScopedCache _cache;
    public CategoriesRepository(Database db, CategoriesScopedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        if (_cache.Categories is not null)
            return _cache.Categories;

        var result = await _db.Categories.ToListAsync();
        _cache.Categories = result;
        return result;
    }
}
