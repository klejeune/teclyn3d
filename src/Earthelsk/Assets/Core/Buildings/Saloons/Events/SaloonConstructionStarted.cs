using Assets.Core.Buildings.Events;
using Assets.Lib.Events;

namespace Assets.Core.Buildings.Models.Saloons
{
    public class SaloonConstructionStarted : BuildingConstructionStarted<Buildings.Saloons.Models.Saloon>
    {
        public override void Apply(Buildings.Saloons.Models.Saloon worldObject, IEventInformation information)
        {
            worldObject.StartConstruction(information.Type(this));
        }
    }
}