using Pinya_Presentations.Modules.Common;
using Pinya_Presentations.Modules.Orders.Events;
using Pinya_Presentations.Modules.Sales.Shared;

namespace Pinya_Presentations.Modules.Sales.EventHandlers;

public class OrderCompletedEventHandler : IEventHandler
{
    private readonly SalesAmountProvider _salesAmount;
    public OrderCompletedEventHandler(SalesAmountProvider salesAmount)
    {
        _salesAmount = salesAmount;
    }

    public void HandleEvent(IDomainEvent @event)
    {
        if (@event is OrderCompletedEvent orderCompleted)
            _salesAmount.Add(orderCompleted.ItemsAmount);
    }
}
