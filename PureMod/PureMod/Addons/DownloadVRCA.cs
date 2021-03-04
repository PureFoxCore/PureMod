using PureMod.API;
using System.Diagnostics;

namespace PureMod.Addons
{
    public class DownloadVRCA : ModSystem
    {
        public override int LoadOrder => 1;
        public override string ModName => "Download VRCA";

        public override void OnStart()
        {
            new ButtonAPI.SingleButton(QMmenu.userMenuP1.GetMenuName(), 2, 0, true, "Download VRCA", "Download VRCA file of selected user's avatar", delegate ()
            {
                Process.Start(Utils.GetSelectedPlayer().field_Internal_VRCPlayer_0.prop_ApiAvatar_0.assetUrl);
            });
        }
    }
}
