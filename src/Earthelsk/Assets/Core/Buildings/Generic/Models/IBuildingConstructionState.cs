using System;
using Assets.Core.ValueTypes;

namespace Assets.Core.Buildings.Generic.Models
{
    public interface IBuildingConstructionState
    {
        DateTime StartDate { get; }
        DateTime? EndDate { get; }
        ConstructionUnit Current { get; }
        ConstructionUnit Total { get; }
        decimal Percent { get; }
        bool IsFinished { get; }
    }
}