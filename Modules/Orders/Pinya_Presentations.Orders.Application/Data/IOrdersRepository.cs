using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Application.Data;

public interface IOrdersRepository
{
    public Task<Order?> CreateAsync(Order order);
    public Task<Order?> GetDetailedAsync(Guid id);
    public Task<IEnumerable<Order>> GetAllAsync();
}
