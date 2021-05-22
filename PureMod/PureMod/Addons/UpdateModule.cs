using System;
using System.IO;
using PureMod.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    class UpdateModule : ModBase
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

                    ModUtils.PureModLogger.Info("File removed, you need to restart VRChat");
                }
                else
                    ModUtils.PureModLogger.Warn("File not exits");
            });
        }
    }
}
