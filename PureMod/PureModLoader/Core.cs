using System;
using System.IO;
using MelonLoader;
using System.Linq;
using PureMod.API;
using System.Reflection;
using PureModLoader.API.Logger;
using System.Collections.Generic;
using Logger = PureModLoader.API.Logger.Logger;

namespace PureModLoader
{
    public class Core : MelonMod
    {
        public static Logger CoreLogger = new Logger("PureModLoader", LogLevel.Trace);
        
        private static List<ModuleBase> Mods = new List<ModuleBase>();

        private void LoadMods()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "PureMod\\Mods")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "PureMod\\Mods"));

            var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "PureMod\\Mods"));

            foreach (var file in files)
            {
                try
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(file);
                        CoreLogger.Info($"[{file}] Loaded!");

                        var result = new List<Type>();
                        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                        foreach (var assembly in assemblies)
                        {
                            var types = assembly.GetTypes();
                            foreach (var type in types)
                                if (type.IsSubclassOf(typeof(ModuleBase)))
                                    result.Add(type);
                        }

                        foreach (var item in result)
                            Mods.Add((ModuleBase)Activator.CreateInstance(item));

                        Mods = Mods.OrderBy(owo => owo.LoadOrder).ToList();
                    }
                }
                catch (Exception ex)
                {
                    CoreLogger.Error($"Can't Load {file}!");
                    CoreLogger.Error(ex.ToString());
                }
            }
        }

        public override void OnApplicationStart()
        {
            Console.Title = "PureModLoader by PureFoxCore#5212";

            LoadMods(); 

            foreach (ModuleBase mod in Mods)
            {
                if (mod.ShowName)
                    CoreLogger.Trace($"{mod.ModName} loaded!");

                mod.OnEarlierStart();
            }
            CoreLogger.Info($"Loaded {Mods.Count} mods!");

            new System.Threading.Timer((e) =>
            {
                foreach (ModuleBase mod in Mods)
                    mod.OnUpdate10();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        public override void VRChat_OnUiManagerInit()
        {
            foreach (ModuleBase mod in Mods)
                mod.OnStart();
        }

        public override void OnUpdate()
        {
            foreach (ModuleBase mod in Mods)
                mod.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            foreach (ModuleBase mod in Mods)
                mod.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            foreach (ModuleBase mod in Mods)
                mod.OnFixedUpdate();
        }

        public override void OnGUI()
        {
            foreach (ModuleBase mod in Mods)
                mod.OnGUI();
        }

        public override void OnApplicationQuit()
        {
            foreach (ModuleBase mod in Mods)
                mod.OnQuit();
        }
    }
}
