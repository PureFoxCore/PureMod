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

        private static List<ModuleBase> Modules = new List<ModuleBase>();

        private void LoadModules()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "PureMod\\Modules")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "PureMod\\Modules"));
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "PureMod\\Configs")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "PureMod\\Configs"));

            var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "PureMod\\Modules"));

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
                            Modules.Add((ModuleBase)Activator.CreateInstance(item));

                        Modules = Modules.OrderBy(owo => owo.LoadOrder).ToList();
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

            LoadModules();

            foreach (ModuleBase module in Modules)
            {
                if (module.ShowName)
                    CoreLogger.Trace($"{module.ModName} loaded!");

                module.OnEarlierStart();
            }
            CoreLogger.Info($"Loaded {Modules.Count} modules!");

            new System.Threading.Timer((e) =>
            {
                foreach (ModuleBase module in Modules)
                    module.OnUpdate10();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        public override void VRChat_OnUiManagerInit()
        {
            foreach (ModuleBase module in Modules)
                module.OnStart();
        }

        public override void OnUpdate()
        {
            foreach (ModuleBase module in Modules)
                module.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            foreach (ModuleBase module in Modules)
                module.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            foreach (ModuleBase module in Modules)
                module.OnFixedUpdate();
        }

        public override void OnGUI()
        {
            foreach (ModuleBase module in Modules)
                module.OnGUI();
        }

        public override void OnApplicationQuit()
        {
            foreach (ModuleBase module in Modules)
                module.OnQuit();
        }
    }
}
