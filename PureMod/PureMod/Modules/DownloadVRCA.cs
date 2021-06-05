using PureModLoader.API;
using System.Diagnostics;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    public class DownloadVRCA : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "Download VRCA";

        public override void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.MenuPath, 2, 0, true, "Download VRCA", "Download VRCA file of selected user's avatar", delegate ()
            {
                Process.Start(Utils.SelectedPlayer.prop_ApiAvatar_0.assetUrl);
            });
        }
    }
}
