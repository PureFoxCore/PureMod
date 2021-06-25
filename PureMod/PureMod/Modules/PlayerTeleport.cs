using UnityEngine;
using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class PlayerTeleport
    {
        public int loadOrder = 1;
        public string moduleName = "Player teleport";

        public void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.MenuPath, 3, 0, true, "Teleport", "Teleport to this player", delegate ()
            {
                Utils.LocalPlayer.gameObject.transform.position = Utils.SelectedPlayer.transform.position;
            });
        }
    }
}
