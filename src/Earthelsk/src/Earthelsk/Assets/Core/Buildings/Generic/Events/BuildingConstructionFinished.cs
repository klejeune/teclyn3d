using Assets.Core.Buildings.Models;
using Assets.Lib.Events;

namespace Assets.Core.Buildings.Generic.Events
{
    public class BuildingConstructionFinished : IEvent
    {
        public string AggregateId { get; set; }
    }

    public abstract class BuildingConstructionFinished<TBuilding> : BuildingConstructionFinished, IEvent<TBuilding> where TBuilding : IBuilding
    {
        public abstract void Apply(TBuilding worldObject, IEventInformation information);
    }
}