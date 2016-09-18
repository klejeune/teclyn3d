using Assets.Core.Buildings.Events;
using Assets.Core.Buildings.Generic.Events;
using Assets.Core.Buildings.Saloons.Models;
using Assets.Lib.Events;

namespace Assets.Core.Buildings.Saloons.Events
{
    public class SaloonConstructionUpdated : BuildingConstructionUpdated<Saloon>
    {
        public override void Apply(Saloon worldObject, IEventInformation information)
        {
            worldObject.UpdateConstruction(information.Type(this));
        }
    }
}