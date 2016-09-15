using Assets.Lib.Events;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Dummies
{
    public interface IDummyAggregate : IWorldObject
    {
        void Create(IEventInformation<DummyEvent> eventInformation);
    }
}