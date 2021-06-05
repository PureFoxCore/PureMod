using UnityEngine;
using PureModLoader.API;
using PureMod.Other;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    public class VSync : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "VSync";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.MenuPath, 4, 0, true, "VSync", "Toggle vertical synchronization", delegate (bool state)
            {
                QualitySettings.vSyncCount = state ? 1 : 0;
                ModUtils.PureModLogger.Info(state ? "VSync On" : "VSync Off");
            }, Color.yellow, Color.white);
        }
    }
}