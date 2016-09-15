using System;
using System.Linq;
using System.Reflection;
using Assets.Lib.Dummies;
using Assets.Lib.Ioc;
using Assets.Lib.Repositories;
using Assets.Lib.Tools;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Events
{
    public class EventService
    {
        public Repository Repository { get; set; }

        [Inject]
        public IdGenerator IdGenerator { get; set; }

        [Inject]
        public EventHandlerService EventHandlerService { get; set; }

        [Inject]
        public Time Time { get; set; }

        public void Raise<T>(IEvent<T> @event) where T : IWorldObject
        {
            var eventInformation = this.BuildEventInformation(@event);
            var worldObject = Repository.GetById<T>(@event.AggregateId);

            if (worldObject == null)
            {
                worldObject = this.BuildAggregate<T>();
            }

            @event.Apply(worldObject, null);

            this.LaunchEventHandlers(worldObject, @event, eventInformation);
        }

        private IEventInformation BuildEventInformation(IEvent @event)
        {
            var eventType = @event.GetType();

            var buildTypedEventInformationMethod = this.GetType()
                .GetMethod("BuildTypedEventInformation", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(eventType);

            var result = buildTypedEventInformationMethod.Invoke(this, new object[] { @event });

            return (IEventInformation)result;
        }

        public EventInformation<TEvent> BuildTypedEventInformation<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventInformation = new EventInformation<TEvent>();
            eventInformation.Id = this.IdGenerator.Generate();
            eventInformation.Date = this.Time.Now;
            eventInformation.EventType = @event.GetType().ToString();
            eventInformation.Event = @event;

            return eventInformation;
        }

        private void LaunchEventHandlers(IWorldObject aggregate, IEvent @event, IEventInformation eventInformation)
        {
            var eventTypeAncestors = @event.GetType().GetAllAncestorsAndInterfaces();

            var handlers = eventTypeAncestors
                .SelectMany(ancestorType => this.EventHandlerService.GetEventHandlers(ancestorType))
                .Select(handler => handler.GetHandleAction(aggregate, @event, eventInformation));

            foreach (var handler in handlers)
            {
                handler();
            }
        }

        private TAggregate BuildAggregate<TAggregate>() where TAggregate : IWorldObject
        {
            return (TAggregate)Activator.CreateInstance(typeof(TAggregate));
        }
    }
}