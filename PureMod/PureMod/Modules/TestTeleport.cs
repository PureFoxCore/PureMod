using UnityEngine;
using PureMod.API;
using PureModLoader.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Modules
{
    public class PlayerTeleport : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Player teleport";

        public override void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.GetMenuName(), 3, 0, true, "Teleport", "Teleport to this player", delegate ()
            {
                Utils.GetLocalPlayer().gameObject.transform.position = Utils.GetSelectedPlayer().transform.position;
            });
        }
    }
}
