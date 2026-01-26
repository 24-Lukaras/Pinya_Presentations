using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Common;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class GetCompletedOrders : Slice<GetCompletedRecordQuery, IEnumerable<Order>>
{
    private readonly OrdersRepository _repo;
    public GetCompletedOrders(OrdersRepository repo, ILogger<GetCompletedOrders> logger) : base(logger)
    {
        _repo = repo;
    }

    protected override (string? Error, IEnumerable<Order>? Result) HandleInternal(GetCompletedRecordQuery input)
    {
        return (null, _repo.GetByStatus(OrderStatus.Completed));
    }

    protected override string? Validate(GetCompletedRecordQuery input) => null;
}
public record GetCompletedRecordQuery();
