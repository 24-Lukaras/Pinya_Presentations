namespace Pinya_Presentations.Modules.Common;

public class EventPublisher
{
    private readonly IEnumerable<IEventHandler> _eventHandlers;
    public EventPublisher(IEnumerable<IEventHandler> eventHandlers)
    {
        _eventHandlers = eventHandlers;
    }

    public void PublishEvent(IDomainEvent @event)
    {
        foreach (var eventHandler in _eventHandlers)
            eventHandler.HandleEvent(@event);
    }
}

public interface IDomainEvent { }
public interface IEventHandler
{
    public void HandleEvent(IDomainEvent @event);
}
