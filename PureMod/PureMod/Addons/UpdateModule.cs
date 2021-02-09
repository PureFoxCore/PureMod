using System;
using System.IO;
using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    class UpdateModule : ModSystem
    {
        public override int LoadOrder => 9;

        public override string ModName => "UpdateModule";

        public override void OnStart()
        {
            new QuickMenuSingleHalfButton(QuickMenuMenu.mainMenuP1, 4, 0, "Update", delegate ()
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, "Mods\\PureMod.dll");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Utils.CoreLogger.Info("File removed, you need to restart VRChat");
                }
                else
                    Utils.CoreLogger.Warn("File not exits");
            }, "Update PureMod");
        }
    }
}
