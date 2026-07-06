using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Products.Database;
using Pinya_Presentations.Products.Domain;

namespace Pinya_Presentations.Products.Features;

public interface IAddProductHandler
{
    public Task<Guid?> AddAsync(string title);
}
internal sealed class AddProduct : IAddProductHandler
{
    private readonly ProductsDb _db;
    public AddProduct(ProductsDb db)
    {
        _db = db;
    }

    public async Task<Guid?> AddAsync(string title)
    {
        if (string.IsNullOrEmpty(title))
            return null;
        var existing = await _db.Products.FirstOrDefaultAsync(x => x.Title == title);
        if (existing is not null)
            return null;
        var entity = new Product(title);
        await _db.Products.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity.Id;
    }
}
