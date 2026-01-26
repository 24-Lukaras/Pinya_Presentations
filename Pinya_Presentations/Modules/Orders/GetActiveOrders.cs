using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Common;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class GetActiveOrders : Slice<GetActiveOrdersQuery, IEnumerable<Order>>
{
    private readonly OrdersRepository _repo;
    public GetActiveOrders(OrdersRepository repo, ILogger<GetActiveOrders> logger) : base(logger)
    {
        _repo = repo;
    }

    protected override (string? Error, IEnumerable<Order>? Result) HandleInternal(GetActiveOrdersQuery input)
    {
        return (null, _repo.GetByStatus(OrderStatus.Active));
    }

    protected override string? Validate(GetActiveOrdersQuery input) => null;
}
public record GetActiveOrdersQuery();
