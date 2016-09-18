using Assets.Core.Buildings.Models;
using Assets.Core.ValueTypes;
using Assets.Lib.Events;

namespace Assets.Core.Buildings.Generic.Events
{
    public abstract class BuildingConstructionUpdated : IEvent
    {
        public ConstructionUnit Amount { get; set; }
        public string AggregateId { get; set; }
    }

    public abstract class BuildingConstructionUpdated<TBuilding> : BuildingConstructionUpdated, IEvent<TBuilding> where TBuilding : IBuilding
    {
        public abstract void Apply(TBuilding worldObject, IEventInformation information);
    }
}