using System;
using System.IO;
using PureModLoader.API;
using PureMod.Other;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    class UpdateModule : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "UpdateModule";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.MenuPath, 1, 1, true, "Update", "Update PureMod", delegate ()
            {
                var modFile = Path.Combine(Environment.CurrentDirectory, "PureMod\\Modules\\PureMod.dll");
                if (File.Exists(modFile))
                {
                    try { File.Delete(modFile); }
                    catch { throw; }

                    using (System.Net.WebClient client = new System.Net.WebClient())
                        client.DownloadFileAsync(new Uri("https://github.com/PureFoxCore/PureMod/releases/latest/download/PureMod.dll"), modFile);

                    ModUtils.PureModLogger.Info("File removed, you need to restart VRChat");
                }
                else
                    ModUtils.PureModLogger.Warn("File not exits");
            });
        }
    }
}
