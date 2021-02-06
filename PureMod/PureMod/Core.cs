using MelonLoader;
using PureMod.API;
using PureMod.API.Logger;
using System.Collections.Generic;

namespace PureMod
{
    public class Core : MelonMod
    {
        public static List<ModSystem> Mods = new List<ModSystem>();
        public static Logger CoreLogger = new Logger("PureMod", LogLevel.Trace);

        public override void OnApplicationStart()
        {
            Mods.Add(new Addons.QuickMenuMenu());

            Mods.Add(new Addons.Fly());
            Mods.Add(new Addons.Test());
            Mods.Add(new Addons.EarRape());
            Mods.Add(new Addons.Teleport());
            Mods.Add(new Addons.AllowClone());

            foreach (ModSystem mod in Mods)
            {
                if (mod.ShowName)
                    CoreLogger.Trace($"{mod.ModName} loaded!");
                mod.OnEarlierStart();
            }
        }

        public override void VRChat_OnUiManagerInit()
        {
            foreach (ModSystem mod in Mods)
                mod.OnStart();
        }

        public override void OnUpdate()
        {
            foreach (ModSystem mod in Mods)
                mod.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            foreach (ModSystem mod in Mods)
                mod.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            foreach (ModSystem mod in Mods)
                mod.OnFixedUpdate();
        }

        public override void OnGUI()
        {
            foreach (ModSystem mod in Mods)
                mod.OnGUI();
        }

        public override void OnApplicationQuit()
        {
            foreach (ModSystem mod in Mods)
                mod.OnQuit();
        }
    }
}
