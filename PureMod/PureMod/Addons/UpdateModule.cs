using System;
using System.IO;
using PureMod.API;
using PureModLoader.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    class UpdateModule : ModSystem
    {
        public override int LoadOrder => 1;
        public override string ModName => "UpdateModule";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.GetMenuName(), 1, 1, true, "Update", "Update PureMod", delegate ()
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, "PureMod\\PureMod.dll");
                if (File.Exists(filePath))
                {
                    try { File.Delete(filePath); }
                    catch { throw; }

                    Utils.CoreLogger.Info("File removed, you need to restart VRChat");
                }
                else
                    Utils.CoreLogger.Warn("File not exits");
            });
        }
    }
}
