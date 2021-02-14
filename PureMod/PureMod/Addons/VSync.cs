using UnityEngine;
using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class VSync : ModSystem
    {
        public override int LoadOrder => 6;
        public override string ModName => "VSync";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 4, 0, true, "VSync", "Toggle vertical synchronization", delegate (bool state)
            {
                QualitySettings.vSyncCount = state ? 1 : 0;
                Utils.CoreLogger.Info(state ? "VSync On" : "VSync Off");
            }, Color.yellow, Color.white);
        }
    }
}
