using System;
using Assets.Core.Buildings.Events;
using Assets.Core.Buildings.Generic.Events;
using Assets.Core.Buildings.Generic.Models;
using Assets.Core.Buildings.Saloons.Events;
using Assets.Lib.Events;

namespace Assets.Core.Buildings.Models
{
    public abstract class AbstractBuilding : IBuilding
    {
        public abstract string Id { get; set; }
        public abstract string Name { get; set; }
        public DateTime ConstructionStartDate { get; set; }
        public IBuildingConstructionState ConstructionState { get { return this.constructionState; } }

        protected BuildingConstructionState constructionState = new BuildingConstructionState();
        
        protected void StartConstruction(IEventInformation<BuildingConstructionStarted> eventInformation)
        {
            this.Id = eventInformation.Event.AggregateId;
            this.Name = eventInformation.Event.Name;
            this.ConstructionStartDate = eventInformation.Date;
            this.constructionState.Current = eventInformation.Event.StartingConstructionUnits;
            this.constructionState.Total = eventInformation.Event.RequiredConstructionUnits;
        }

        protected void UpdateConstruction(IEventInformation<BuildingConstructionUpdated> eventInformation)
        {
            this.constructionState.Current += eventInformation.Event.Amount;
        }

        protected void FinishConstruction(IEventInformation<BuildingConstructionFinished> eventInformation)
        {
            this.constructionState.EndDate = eventInformation.Date;
        }
    }
}