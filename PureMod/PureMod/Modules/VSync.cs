using UnityEngine;
using PureMod.API;
using PureMod.Other;
using PureModLoader.ButtonAPI;

namespace PureMod.Modules
{
    public class VSync : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "VSync";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 4, 0, true, "VSync", "Toggle vertical synchronization", delegate (bool state)
            {
                QualitySettings.vSyncCount = state ? 1 : 0;
                ModUtils.PureModLogger.Info(state ? "VSync On" : "VSync Off");
            }, Color.yellow, Color.white);
        }
    }
}