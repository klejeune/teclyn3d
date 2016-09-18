using Assets.Lib.Events;

namespace Assets.Lib.Dummies
{
    public class DummyEvent : IEvent<IDummyAggregate>
    {
        public void Apply(IDummyAggregate aggregate, IEventInformation information)
        {
            aggregate.Create(information.Type(this));
        }

        public string AggregateId { get; set; }
    }
}