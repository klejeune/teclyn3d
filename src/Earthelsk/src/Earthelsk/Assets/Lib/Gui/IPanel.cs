using System.Collections;
using System.Collections.Generic;

namespace Assets.Lib.Gui
{
    public interface IPanel
    {
        IEnumerable<PanelAction> GetActions(TeclynUnity teclyn);
    }
}