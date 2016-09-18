using System;
using Assets.Core.ValueTypes;

namespace Assets.Core.Buildings.Generic.Models
{
    public class BuildingConstructionState : IBuildingConstructionState
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ConstructionUnit Current { get; set; }
        public ConstructionUnit Total { get; set; }
        public decimal Percent { get { return this.Current / this.Total; } }
        public bool IsFinished { get { return this.EndDate.HasValue; } }
    }
}