using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Products.Database;
using Pinya_Presentations.Products.Dto;

namespace Pinya_Presentations.Products.Features;

public interface IGetBriefProductsHandler
{
    public Task<IEnumerable<BriefProductDto>> GetAsync();
}
internal sealed class GetBriefProducts : IGetBriefProductsHandler
{
    private readonly ProductsDb _db;
    public GetBriefProducts(ProductsDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<BriefProductDto>> GetAsync()
    {
        var entities = await _db.Products.ToListAsync();
        return entities
            .Select(BriefProductDto.FromEntity)
            .ToList();
    }
}
