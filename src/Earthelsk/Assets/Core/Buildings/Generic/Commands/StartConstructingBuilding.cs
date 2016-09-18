using System;
using Assets.Core.Buildings.Events;
using Assets.Core.Buildings.Models;
using Assets.Core.ValueTypes;
using Assets.Lib.Commands;

namespace Assets.Core.Buildings.Commands
{
    public abstract class StartConstructingBuilding<TBuilding, TEvent> : ICommand where TBuilding : IBuilding where TEvent : BuildingConstructionStarted<TBuilding>
    {
        public TileLocation Location { get; set; }
        public Orientation Orientation { get; set; }

        protected virtual TEvent BuildEvent(ICommandContext context)
        {
            var @event = (TEvent)Activator.CreateInstance(typeof(TEvent));
            @event.AggregateId = context.GetIdGenerator().Generate();
            @event.Location = this.Location;
            @event.Orientation = this.Orientation;

            return @event;
        }

        public void Execute(ICommandContext context)
        {
            context.GetEventService().Raise<TBuilding>(this.BuildEvent(context));
        }
    }
}