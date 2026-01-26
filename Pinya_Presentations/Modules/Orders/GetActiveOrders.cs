using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class GetActiveOrders
{
    private readonly OrdersRepository _repo;
    public GetActiveOrders(OrdersRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Order> Get() => _repo.GetByStatus(OrderStatus.Active);
}
