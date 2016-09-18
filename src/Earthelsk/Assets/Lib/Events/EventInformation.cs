using System;

namespace Assets.Lib.Events
{
    public class EventInformation<TEvent> : IEventInformation<TEvent> where TEvent : IEvent
    {
        public TEvent Event { get; set; }
        public DateTime Date { get; set; }
        public string EventType { get; set; }

        public IEventInformation<TEvent1> Type<TEvent1>(TEvent1 @event) where TEvent1 : IEvent
        {
            return (IEventInformation<TEvent1>)this;
        }

        public string Id { get; set; }
    }
}