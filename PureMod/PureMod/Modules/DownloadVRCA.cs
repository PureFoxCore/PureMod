using PureModLoader.API;
using System.Diagnostics;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class DownloadVRCA
    {
        public int loadOrder = 1;
        public string moduleName = "Download VRCA";

        public void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.MenuPath, 2, 0, true, "Download VRCA", "Download VRCA file of selected user's avatar", delegate ()
            {
                Process.Start(Utils.SelectedPlayer.prop_ApiAvatar_0.assetUrl);
            });
        }
    }
}
