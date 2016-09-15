using Assets.Core.Buildings;
using Assets.Core.Buildings.Models.Saloons;
using Assets.Core.ValueTypes;
using Assets.Lib;
using Assets.Lib.Commands;

namespace Assets.Tests
{
    public class EarthelskTests
    {
        private TeclynUnity teclyn;
        private CommandService commandService;

        public EarthelskTests()
        {
            this.teclyn = TeclynUnity.Initialize();
            this.commandService = this.teclyn.Get<CommandService>();
        }

        public void Test()
        {
            this.commandService.Create<StartSaloonConstruction>(_ => 
            {
                _.Location = new TileLocation(0, 0);
                _.Orientation = Orientation.North;
            });
        }
    }
}