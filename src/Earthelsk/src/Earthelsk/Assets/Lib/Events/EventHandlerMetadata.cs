using System;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Events
{
    public class EventHandlerMetadata
    {
        public string Name { get; private set; }
        public Type EventHandlerType { get; private set; }
        public Type EventType { get; private set; }

        private Action<IWorldObject, IEventInformation> action;
        public EventHandlerMetadata(Type eventHandlerType, Type eventType, Action<IWorldObject, IEventInformation> action)
        {
            this.EventHandlerType = eventHandlerType;
            this.EventType = eventType;
            this.Name = eventHandlerType.Name;
            this.action = action;
        }

        public Action GetHandleAction(IWorldObject aggregate, IEvent @event, IEventInformation eventInformation)
        {
            return () => this.action(aggregate, eventInformation);
        }
    }
}