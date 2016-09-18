using System;
using Assets.Core.Buildings.Events;
using Assets.Lib.Events;
using Assets.Lib.WorldObjects;

namespace Assets.Core.Buildings.Models
{
    public interface IBuilding : IWorldObject
    {
        DateTime ConstructionStartDate { get; }
    }
}