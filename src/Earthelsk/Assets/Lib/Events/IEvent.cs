using Assets.Lib.WorldObjects;

namespace Assets.Lib.Events
{
    public interface IEvent
    {
        string AggregateId { get; }
    }

    public interface IEvent<T> : IEvent where T : IWorldObject
    {
        void Apply(T worldObject, IEventInformation information);
    }
}