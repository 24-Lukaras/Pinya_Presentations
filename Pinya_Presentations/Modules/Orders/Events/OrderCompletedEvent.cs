using Pinya_Presentations.Modules.Common;

namespace Pinya_Presentations.Modules.Orders.Events;

public record OrderCompletedEvent(int ItemsAmount) : IDomainEvent;