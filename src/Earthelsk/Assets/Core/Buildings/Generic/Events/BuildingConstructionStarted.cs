using Assets.Core.Buildings.Models;
using Assets.Core.ValueTypes;
using Assets.Lib.Events;
using Assets.Lib.WorldObjects;

namespace Assets.Core.Buildings.Events
{
    public abstract class BuildingConstructionStarted : IEvent
    {
        public string AggregateId { get; set; }
        public string Name { get; set; }
        public TileLocation Location { get; set; }
        public Orientation Orientation { get; set; }
        public ConstructionUnit RequiredConstructionUnits { get; set; }
        public ConstructionUnit StartingConstructionUnits { get; set; }
    }

    public abstract class BuildingConstructionStarted<TBuilding> : BuildingConstructionStarted, IEvent<TBuilding> where TBuilding : IBuilding
    {
        public abstract void Apply(TBuilding worldObject, IEventInformation information);
    }
}