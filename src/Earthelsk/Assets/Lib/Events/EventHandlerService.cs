using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Lib.Dummies;
using Assets.Lib.Ioc;
using Assets.Lib.Tools;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Events
{
    public class EventHandlerService
    {
        [Inject]
        public TeclynUnity Teclyn { get; set; }

        private IDictionary<Type, List<EventHandlerMetadata>> handlersMetaData = new Dictionary<Type, List<EventHandlerMetadata>>();

        public IEnumerable<EventHandlerMetadata> GetEventHandlers(Type eventType)
        {
            var handlersMetadata = handlersMetaData.GetValueOrDefault(eventType);

            if (handlersMetadata == null)
            {
                return Enumerable.Empty<EventHandlerMetadata>();
            }
            else
            {
                return handlersMetadata;
            }
        }

        public void RegisterEventHandler(Type eventHandlerType)
        {
            var handlerInterfacesWithoutAggregate = eventHandlerType
            .GetInterfaces()
            .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IEventHandler<>))
            .Select(@interface => new KeyValuePair<Type, Action<IWorldObject, IEventInformation>>(@interface.GetGenericArguments()[0],
                (aggregate, eventInformation) =>
                {
                    var handler = Teclyn.Get(eventHandlerType);
                    var method = typeof(IEventHandler<>).MakeGenericType(@interface.GetGenericArguments()[0]).GetMethod("Handle", new[]
                          {
                                typeof(IEventInformation<>).MakeGenericType(@interface.GetGenericArguments()[0])
                          });

                    method.Invoke(handler, new object[] { eventInformation });
                }));

            var handlerInterfacesWithAggregate = eventHandlerType.GetInterfaces()
                .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IEventHandler<,>))
                .Select(@interface => new KeyValuePair<Type, Action<IWorldObject, IEventInformation>>(@interface.GetGenericArguments()[1],
                    (aggregate, eventInformation) =>
                    {
                        var handler = Teclyn.Get(eventHandlerType);
                        var method = typeof(IEventHandler<,>).MakeGenericType(@interface.GetGenericArguments()[0],
                            @interface.GetGenericArguments()[1]).GetMethod("Handle", new[]
                            {
                                @interface.GetGenericArguments()[0],
                                typeof(IEventInformation<>).MakeGenericType(@interface.GetGenericArguments()[1])
                            });

                        method.Invoke(handler, new object[] { aggregate, eventInformation });
                    }));

            var handledEvents = handlerInterfacesWithoutAggregate
                .Union(handlerInterfacesWithAggregate);

            var metadataList = handledEvents.Select(@eventInfo => new EventHandlerMetadata(eventHandlerType, @eventInfo.Key, @eventInfo.Value));

            foreach (var eventHandlerInfo in metadataList)
            {
                var list = handlersMetaData.GetValueOrDefault(eventHandlerInfo.EventType, null);

                if (list == null)
                {
                    list = new List<EventHandlerMetadata>();
                    this.handlersMetaData[eventHandlerInfo.EventType] = list;
                }

                list.Add(eventHandlerInfo);
            }
        }
    }
}