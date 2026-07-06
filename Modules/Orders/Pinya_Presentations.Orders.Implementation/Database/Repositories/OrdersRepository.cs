using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Orders.Application.Data;
using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Implementation.Database.Repositories;

internal class OrdersRepository : IOrdersRepository
{
    private readonly OrdersDb _db;
    public OrdersRepository(OrdersDb db)
    {
        _db = db;
    }

    public async Task<Order?> CreateAsync(Order order)
    {
        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await _db.Orders.AsNoTracking().ToListAsync();

    public Task<Order?> GetDetailedAsync(Guid id) =>
        _db.Orders
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);
}
