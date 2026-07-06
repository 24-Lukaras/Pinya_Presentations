using Pinya_Presentations.Orders.Application.Data;
using Pinya_Presentations.Orders.Application.Dto;
using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Application.Managers;

public class OrdersManager
{
    private readonly IOrdersRepository _data;
    public OrdersManager(IOrdersRepository data)
    {
        _data = data;
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
}
