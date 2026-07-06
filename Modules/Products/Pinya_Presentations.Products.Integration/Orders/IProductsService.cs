using Pinya_Presentations.Products.Integration.Orders.Dto;

namespace Pinya_Presentations.Products.Integration.Orders;

public interface IProductsService
{
    public Task<IEnumerable<FoundProductDto>> SearchProductsAsync(string query);
    public Task<FoundProductDto?> GetProductAsync(Guid id);
    public Task<bool> ReserveAmountAsync(Guid id, int amount);
}
