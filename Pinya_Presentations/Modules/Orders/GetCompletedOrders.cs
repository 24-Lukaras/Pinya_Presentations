using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class GetCompletedOrders
{
    private readonly OrdersRepository _repo;
    public GetCompletedOrders(OrdersRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Order> Get() => _repo.GetByStatus(OrderStatus.Completed);
}
