using UnityEngine;
using PureMod.API;
using PureModLoader.API;
using PureModLoader.UIAPI.QM;

namespace PureMod.Modules
{
    public class PlayerTeleport : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "Player teleport";

        public override void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.GetMenuName(), 3, 0, true, "Teleport", "Teleport to this player", delegate ()
            {
                Utils.LocalPlayer.gameObject.transform.position = Utils.SelectedPlayer.transform.position;
            });
        }
    }
}
