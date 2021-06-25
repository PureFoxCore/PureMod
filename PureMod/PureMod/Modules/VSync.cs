using UnityEngine;
using PureModLoader.API;
using PureMod.Other;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class VSync
    {
        public int loadOrder = 1;
        public string moduleName = "VSync";

        public void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.MenuPath, 4, 0, true, "VSync", "Toggle vertical synchronization", delegate (bool state)
            {
                QualitySettings.vSyncCount = state ? 1 : 0;
                ModUtils.PureModLogger.Info(state ? "VSync On" : "VSync Off");
            }, Color.yellow, Color.white);
        }
    }
}