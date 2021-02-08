using System;
using System.IO;
using System.Net;
using MelonLoader;
using UnityEngine;
using System.Linq;
using System.Reflection;
using PureMod.API;
using PureMod.API.Logger;
using System.Collections.Generic;
using Logger = PureMod.API.Logger.Logger;

namespace PureModLoader
{
    public class Core : MelonMod
    {
        public static List<ModSystem> UnshortedMods = new List<ModSystem>();
        public static List<ModSystem> Mods = new List<ModSystem>();
        public static Logger CoreLogger = new Logger("PureModLoader", LogLevel.Trace);

        private static byte[] buffer;
        private static Assembly assembly;
        private static WebClient client = new WebClient();

        private void FindMods()
        {
            var result = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                    if (type.IsSubclassOf(typeof(ModSystem))) result.Add(type);
            }

            foreach (var item in result)
            {
                var instance = Activator.CreateInstance(item);
                UnshortedMods.Add((ModSystem)instance);
            }

            List<ModSystem> sortedModList = UnshortedMods.OrderBy(owo => owo.LoadOrder).ToList();
            Mods.Clear();

            foreach (var mod in sortedModList)
            {
                Mods.Add(mod);
                if (mod.ShowName)
                    CoreLogger.Trace($"{mod.ModName} loaded!");
            }
        }

        private void LoadMods()
        {
            try
            {
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Mods\\IceBurn.txt")))
                {
                    CoreLogger.Info("IceBurn.txt Exits. Loading From File");
                    buffer = Convert.FromBase64String(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Mods\\PureMod.txt")));
                    assembly = Assembly.Load(buffer);
                    CoreLogger.Info($"Buffer Loaded IN TO RAM [Length: {buffer.Length}]");
                    FindMods();
                }
                else
                {
                    buffer = Convert.FromBase64String(client.DownloadString("https://raw.githubusercontent.com/PureFoxCore/PureMod/main/PureMod/PureMod/output/PureMod.txt"));
                    if (buffer.Length > 1000)
                    {
                        assembly = Assembly.Load(buffer);
                        CoreLogger.Info($"Buffer Loaded IN TO RAM [Length: {buffer.Length}]");
                        FindMods();
                    }
                    else
                    {
                        CoreLogger.Error("IceLoader Can't Load IceBurn2!");
                        CoreLogger.Error("Access Denied!");
                        Application.Quit();
                    }
                }
            }
            catch (Exception ex)
            {
                CoreLogger.Error("IceLoader Can't Load IceBurn2 !");
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
            foreach (ModSystem mod in Mods)
                mod.OnQuit();
        }
    }
}
