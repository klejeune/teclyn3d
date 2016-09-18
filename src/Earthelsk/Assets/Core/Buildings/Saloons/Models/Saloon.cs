using Assets.Core.Buildings.Generic.Models;
using Assets.Core.Buildings.Models;
using Assets.Core.Buildings.Models.Saloons;
using Assets.Core.Buildings.Saloons.Events;
using Assets.Lib.Events;
using Assets.Lib.WorldObjects;

namespace Assets.Core.Buildings.Saloons.Models
{
    [WorldObject]
    public class Saloon : AbstractBuilding
    {
        public override string Id { get; set; }
        public override string Name { get; set; }
        
        public void StartConstruction(IEventInformation<SaloonConstructionStarted> eventInformation)
        {
            base.StartConstruction(eventInformation);
        }

        public void UpdateConstruction(IEventInformation<SaloonConstructionUpdated> eventInformation)
        {
            base.UpdateConstruction(eventInformation);
        }

        public void FinishConstruction(IEventInformation<SaloonConstructionFinished> eventInformation)
        {
            base.FinishConstruction(eventInformation);
        }
    }
}