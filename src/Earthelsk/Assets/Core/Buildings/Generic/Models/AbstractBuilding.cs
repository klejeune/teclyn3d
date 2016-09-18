using System;
using Assets.Core.Buildings.Events;
using Assets.Core.Buildings.Generic.Events;
using Assets.Core.Buildings.Generic.Models;
using Assets.Core.Buildings.Models.Saloons;
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
        
        protected void StartConstruction<T>(IEventInformation<T> eventInformation) where T : BuildingConstructionStarted
        {
            this.Id = eventInformation.Event.AggregateId;
            this.Name = eventInformation.Event.Name;
            this.ConstructionStartDate = eventInformation.Date;
            this.constructionState.Current = eventInformation.Event.StartingConstructionUnits;
            this.constructionState.Total = eventInformation.Event.RequiredConstructionUnits;
        }

        protected void UpdateConstruction<T>(IEventInformation<T> eventInformation) where T : BuildingConstructionUpdated
        {
            this.constructionState.Current += eventInformation.Event.Amount;
        }

        protected void FinishConstruction<T>(IEventInformation<T> eventInformation) where T : BuildingConstructionFinished
        {
            this.constructionState.EndDate = eventInformation.Date;
        }
    }
}