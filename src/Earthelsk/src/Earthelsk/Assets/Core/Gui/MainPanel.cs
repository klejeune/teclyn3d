using System.Collections.Generic;
using Assets.Core.Buildings.Models.Saloons;
using Assets.Core.ValueTypes;
using Assets.Lib;
using Assets.Lib.Commands;
using Assets.Lib.Gui;

namespace Assets.Core.Gui
{
    public class MainPanel : IPanel
    {
        public IEnumerable<PanelAction> GetActions(TeclynUnity teclyn)
        {
            return new[]
            {
                new PanelAction
                {
                    Name = "Build Saloon",
                    Action = () =>
                    {
                        var commandService = teclyn.Get<CommandService>();
                        var command = commandService.Create<StartSaloonConstruction>();
                        command.Location = new TileLocation(0, 0);
                        command.Orientation = Orientation.North;
                        commandService.Execute(command);
                    }
                }
            };
        }
    }
}