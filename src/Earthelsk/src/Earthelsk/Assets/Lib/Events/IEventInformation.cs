using System;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Events
{
    public interface IEventInformation
    {
        IEventInformation<TEvent> Type<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }

    public interface IEventInformation<out TEvent> where TEvent : IEvent
    {
        DateTime Date { get; }
        TEvent Event { get; }
    }
}