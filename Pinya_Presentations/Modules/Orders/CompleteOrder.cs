using MediatR;
using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class CompleteOrder : IRequestHandler<CompleteOrderCommand, bool>
{
    private readonly OrdersRepository _repo;
    public CompleteOrder(OrdersRepository repo)
    {
        _repo = repo;
    }

    public bool Handle(CompleteOrderCommand command)
    {
        var entity = _repo.GetById(command.Id);
        if (entity == null)
            return false;
        if (entity.Status != OrderStatus.Active)
            return false;

        entity.Status = OrderStatus.Completed;
        entity.CompletedAtUtc = DateTime.UtcNow;
        _repo.Save();
        return true;
    }

    public Task<bool> Handle(CompleteOrderCommand request, CancellationToken cancellationToken) => Task.FromResult(Handle(request));
}

public record CompleteOrderCommand(Guid Id) : IRequest<bool>;
