using PureMod.API;
using PureModLoader.API;
using System.Diagnostics;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    public class DownloadVRCA : ModSystem
    {
        public override int LoadOrder => 1;
        public override string ModName => "Download VRCA";

        public override void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.GetMenuName(), 2, 0, true, "Download VRCA", "Download VRCA file of selected user's avatar", delegate ()
            {
                Process.Start(Utils.GetSelectedPlayer().prop_ApiAvatar_0.assetUrl);
            });
        }
    }
}
