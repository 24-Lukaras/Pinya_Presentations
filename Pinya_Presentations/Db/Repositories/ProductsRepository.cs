using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db.Entities;
using Pinya_Presentations.Services;

namespace Pinya_Presentations.Db.Repositories;

public class ProductsRepository
{
    private readonly Database _db;
    private readonly ProductsCache _cache;
    public ProductsRepository(Database db, ProductsCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var cached = _cache.GetAll();
        if (cached is not null)
            return cached;

        var products = await _db.Products.ToArrayAsync();
        _cache.Set(products);
        return products;
    }
}
