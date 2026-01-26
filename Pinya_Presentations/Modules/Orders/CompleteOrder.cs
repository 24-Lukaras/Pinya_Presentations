using Pinya_Presentations.Domain;
using Pinya_Presentations.Modules.Common;
using Pinya_Presentations.Modules.Orders.Events;
using Pinya_Presentations.Modules.Orders.Shared;

namespace Pinya_Presentations.Modules.Orders;

public class CompleteOrder : Slice<CompleteOrderCommand, bool>
{
    private readonly EventPublisher _events;
    private readonly OrdersRepository _repo;
    public CompleteOrder(EventPublisher events, OrdersRepository repo, ILogger<CompleteOrder> logger) : base(logger)
    {
        _events = events;
        _repo = repo;
    }
    protected override string? Validate(CompleteOrderCommand input)
    {
        if (input.Id == default)
        {
            _logger.LogWarning($"Invalid id [{input.Id}] provided to CompleteOrder");
            return "Invalid id";
        }
        return null;
    }

    protected override (string?, bool) HandleInternal(CompleteOrderCommand input)
    {
        var entity = _repo.GetById(input.Id);
        if (entity == null)
            return ("Order not found", false);
        if (entity.Status != OrderStatus.Active)
            return ("Order is not active", false);

        entity.Status = OrderStatus.Completed;
        entity.CompletedAtUtc = DateTime.UtcNow;
        _events.PublishEvent(new OrderCompletedEvent(entity.Items.Sum(x => x.Amount)));
        _repo.Save();
        return (null, true);
    }
}

public record CompleteOrderCommand(Guid Id);
