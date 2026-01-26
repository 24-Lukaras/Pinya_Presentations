using MediatR;
using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class GetActiveOrders : IRequestHandler<GetActiveOrdersQuery, IEnumerable<Order>>
{
    private readonly OrdersRepository _repo;
    public GetActiveOrders(OrdersRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Order> Get() => _repo.GetByStatus(OrderStatus.Active);

    public Task<IEnumerable<Order>> Handle(GetActiveOrdersQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(Get());
}

public record GetActiveOrdersQuery() : IRequest<IEnumerable<Order>>;
