using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Products.Database;
using Pinya_Presentations.Products.Domain;
using Pinya_Presentations.Products.Integration.Orders;
using Pinya_Presentations.Products.Integration.Orders.Dto;

namespace Pinya_Presentations.Products.Integrations;

internal class ProductsForOrdersService : IProductsService
{
    private readonly ProductsDb _db;
    public ProductsForOrdersService(ProductsDb db)
    {
        _db = db;
    }

    public async Task<FoundProductDto?> GetProductAsync(Guid id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product is null)
            return null;
        return GetFoundDto(product);
    }

    public async Task<bool> ReserveAmountAsync(Guid id, int amount)
    {
        var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product is null)
            return false;
        var result = product.TryReserveAmount(amount);
        if (result)
            await _db.SaveChangesAsync();
        return result;
    }

    public async Task<IEnumerable<FoundProductDto>> SearchProductsAsync(string query)
    {
        var products = await _db.Products
            .Where(x => x.Title.Contains(query))
            .Take(5)
            .ToListAsync();
        return products.Select(GetFoundDto).ToArray();
    }

    private static FoundProductDto GetFoundDto(Product product) =>
        new FoundProductDto()
        {
            Id = product.Id,
            Title = product.Title,
            AvailableAmount = product.AvailableAmount
        };
}
