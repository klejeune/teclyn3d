using Assets.Lib.WorldObjects;

namespace Assets.Lib.Events
{
    public interface IEventHandler
    {

    }

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
    {
        void Handle(IEventInformation<TEvent> @event);
    }

    public interface IEventHandler<in TAggregate, in TEvent> : IEventHandler where TAggregate : class, IWorldObject where TEvent : IEvent<TAggregate>
    {
        void Handle(TAggregate aggregate, IEventInformation<TEvent> @event);
    }
}