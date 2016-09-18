using Assets.Core.Buildings.Generic.Events;
using Assets.Core.Buildings.Saloons.Models;
using Assets.Lib.Events;

namespace Assets.Core.Buildings.Saloons.Events
{
    public class SaloonConstructionFinished : BuildingConstructionFinished<Saloon>
    {
        public override void Apply(Saloon worldObject, IEventInformation information)
        {
            worldObject.FinishConstruction(information.Type(this));
        }
    }
}