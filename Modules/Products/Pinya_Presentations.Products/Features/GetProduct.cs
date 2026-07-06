using Pinya_Presentations.Products.Database;
using Pinya_Presentations.Products.Dto;

namespace Pinya_Presentations.Products.Features;

public interface IGetProductHandler
{
    public Task<ProductDto?> GetAsync(Guid id);
}
internal sealed class GetProduct : IGetProductHandler
{
    private readonly ProductsDb _db;
    public GetProduct(ProductsDb db)
    {
        _db = db;
    }

    public async Task<ProductDto?> GetAsync(Guid id)
    {
        var entity = await _db.Products.FindAsync(id);
        if (entity is null)
            return null;
        return ProductDto.FromEntity(entity);
    }
}
