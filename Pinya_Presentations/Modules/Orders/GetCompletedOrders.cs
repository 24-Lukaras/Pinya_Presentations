using MediatR;
using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class GetCompletedOrders : IRequestHandler<GetCompletedOrderQuery, IEnumerable<Order>>
{
    private readonly OrdersRepository _repo;
    public GetCompletedOrders(OrdersRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Order> Get() => _repo.GetByStatus(OrderStatus.Completed);

    public Task<IEnumerable<Order>> Handle(GetCompletedOrderQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(Get());
}

public record GetCompletedOrderQuery() : IRequest<IEnumerable<Order>>;
