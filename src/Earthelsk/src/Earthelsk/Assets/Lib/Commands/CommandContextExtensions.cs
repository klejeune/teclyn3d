using Assets.Lib.Events;
using Assets.Lib.Tools;

namespace Assets.Lib.Commands
{
    public static class CommandContextExtensions
    {
        public static EventService GetEventService(this ICommandContext context)
        {
            return context.Teclyn.Get<EventService>();
        }

        public static IdGenerator GetIdGenerator(this ICommandContext context)
        {
            return context.Teclyn.Get<IdGenerator>();
        }
    }
}