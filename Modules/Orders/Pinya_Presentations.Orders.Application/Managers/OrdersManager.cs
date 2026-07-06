using Pinya_Presentations.Orders.Application.Data;
using Pinya_Presentations.Orders.Application.Dto;
using Pinya_Presentations.Orders.Domain;
using Pinya_Presentations.Products.Integration.Orders;
using Pinya_Presentations.Products.Integration.Orders.Dto;

namespace Pinya_Presentations.Orders.Application.Managers;

public class OrdersManager
{
    private readonly IOrdersRepository _data;
    private readonly IProductsService _productsService;
    public OrdersManager(IOrdersRepository data,
        IProductsService productsService)
    {
        _data = data;
        _productsService = productsService;
    }

    public async Task<BriefOrderDto?> CreateOrderAsync(string customer)
    {
        var order = new Order(customer);
        var result = await _data.CreateAsync(order);
        if (result is null)
            return null;
        return BriefOrderDto.FromEntity(result);
    }

    public async Task<IEnumerable<BriefOrderDto>> GetOrdersAsync()
    {
        var orders = await _data.GetAllAsync();
        return orders
            .Select(BriefOrderDto.FromEntity)
            .ToList();
    }

    public async Task<OrderDto?> GetOrderAsync(Guid id)
    {
        var order = await _data.GetDetailedAsync(id);
        if (order is null)
            return null;
        return OrderDto.FromEntity(order);
    }

    public Task<IEnumerable<FoundProductDto>> SearchProducts(string query) =>
        _productsService.SearchProductsAsync(query);
    public async Task<bool> AddItemAsync(Guid orderId, Guid productId, int amount)
    {
        var order = await _data.GetDetailedAsync(orderId);
        if (order is null)
            return false;
        var product = await _productsService.GetProductAsync(productId);
        if (product is null)
            return false;

        var item = order.AddItem(productId, product.Title, amount);
        await _data.SaveChangesAsync();

        var productReserved = await _productsService.ReserveAmountAsync(productId, amount);
        if (productReserved)
            return true;

        order.RemoveItem(productId, amount);
        await _data.SaveChangesAsync();
        return false;
    }
}
