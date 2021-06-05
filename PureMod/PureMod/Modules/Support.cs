using PureModLoader.API;
using UnityEngine;
using System.Diagnostics;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    public class Support : ModuleBase
    {
        public override int LoadOrder => 1;
        public override bool ShowName => false;

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP3.MenuPath, 5, 4, true, "Support", "Support PureMod", delegate()
            {
                Process.Start("https://www.donationalerts.com/c/purefoxcore");
            }, Color.green, Color.white);
        }
    }
}
