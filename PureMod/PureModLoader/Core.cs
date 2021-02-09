using System;
using System.IO;
using System.Net;
using MelonLoader;
using System.Linq;
using PureMod.API;
using System.Reflection;
using PureMod.API.Logger;
using System.Collections.Generic;
using Logger = PureMod.API.Logger.Logger;

namespace PureModLoader
{
    public class Core : MelonMod
    {
        public static List<ModSystem> Mods = new List<ModSystem>();
        public static Logger CoreLogger = new Logger("PureModLoader", LogLevel.Trace);

        private static WebClient client = new WebClient();

        private void LoadMods()
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Mods\\PureMod.file");

            try
            {
                if (!File.Exists(filePath))
                    client.DownloadFile("https://raw.githubusercontent.com/PureFoxCore/PureMod/main/PureMod/PureMod/output/PureMod.file", filePath);

                if (File.Exists(filePath))
                {
                    Assembly.LoadFile(filePath);
                    CoreLogger.Info("PureMod Loaded");

                    var result = new List<Type>();
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                    foreach (var assembly in assemblies)
                    {
                        var types = assembly.GetTypes();
                        foreach (var type in types)
                            if (type.IsSubclassOf(typeof(ModSystem)))
                                result.Add(type);
                    }

                    foreach (var item in result)
                        Mods.Add((ModSystem)Activator.CreateInstance(item));

                    Mods = Mods.OrderBy(owo => owo.LoadOrder).ToList();
                }
                else
                    CoreLogger.Error("Can't Load PureMod!");
            }
            catch (Exception ex)
            {
                CoreLogger.Error("Can't Load PureMod!");
                CoreLogger.Error(ex.ToString());
            }
        }

        public override void OnApplicationStart()
        {
            LoadMods();

            foreach (ModSystem mod in Mods)
                mod.OnEarlierStart();
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
            string filePath = Path.Combine(Environment.CurrentDirectory, "Mods\\PureMod.file");

            if (File.Exists(filePath))
                File.Delete(filePath);

            foreach (ModSystem mod in Mods)
                mod.OnQuit();
        }
    }
}
