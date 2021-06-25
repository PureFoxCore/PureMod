using System;
using System.IO;
using MelonLoader;
using System.Linq;
using PureModLoader.API;
using System.Reflection;
using PureModLoader.API.Logger;
using System.Collections.Generic;
using Logger = PureModLoader.API.Logger.Logger;

namespace PureModLoader
{
    public class Core : MelonMod
    {
        public static Logger CoreLogger = new Logger("PureModLoader", LogLevel.Trace);

        private static List<Type> modules = new List<Type>();

        private void LoadModules()
        {
            if (!Directory.Exists(Utils.ModulesDirectory))
                Directory.CreateDirectory(Utils.ModulesDirectory);
            if (!Directory.Exists(Utils.ConfigsDirectory))
                Directory.CreateDirectory(Utils.ConfigsDirectory);

            var dllFiles = Directory.GetFiles(Utils.ModulesDirectory, "*.dll");

            foreach (var file in dllFiles)
            {
                try
                {
                    var currentFileAssembly = Assembly.LoadFile(file);
                    CoreLogger.Info($"[{file}] Loaded!");

                    foreach (var type in currentFileAssembly.GetTypes())
                        if (Attribute.IsDefined(type, typeof(ModuleAttribute)))
                            foreach (var field in type.GetFields())
                                CoreLogger.Trace($"{field.Name}: {field.GetValue(type.Module.Assembly)}");
                    //modules.Add(type);

                    modules = modules.OrderBy(owo => owo.GetField("loadOrder") == null ? 0 : (int)owo.GetField("loadOrder").GetValue(owo)).ToList();
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

            foreach (var module in modules)
            {
                if (module.GetField("moduleName") != null)
                    CoreLogger.Trace($"{(string)module.GetField("moduleName").GetValue(module)} loaded!");

                module.GetMethod("OnAwake").Invoke(module, null);
            }
            CoreLogger.Info($"Loaded {modules.Count} modules!");

            if (typeof(MelonMod).GetMethod("VRChat_OnUiManagerInit") == null)
                MelonCoroutines.Start(GetAssembly());
        }

        private static System.Collections.IEnumerator GetAssembly()
        {
            Assembly assembly;
            while (true)
            {
                assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == "Assembly-CSharp");
                if (!(assembly == null))
                    break;
                yield return null;
            }
            MelonCoroutines.Start(WaitForUiManagerInit(assembly));
            yield break;
        }

        private static System.Collections.IEnumerator WaitForUiManagerInit(Assembly assemblyCSharp)
        {
            Type vrcUiManager = assemblyCSharp.GetType("VRCUiManager");
            PropertyInfo uiManagerSingleton = vrcUiManager.GetProperties().First((PropertyInfo pi) => pi.PropertyType == vrcUiManager);
            while (uiManagerSingleton.GetValue(null) == null)
                yield return null;
            OnUiManagerInit();
            yield break;
        }

        private static void OnUiManagerInit()
        {
            new System.Threading.Timer((e) =>
            {
                foreach (var module in modules)
                    module.GetMethod("OnUpdate10").Invoke(module, null);
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            new System.Threading.Timer((e) =>
            {
                foreach (var module in modules)
                    module.GetMethod("OnUpdate1").Invoke(module, null);
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            foreach (var module in modules)
                module.GetMethod("OnStart").Invoke(module, null);

            MelonCoroutines.Start(Init());
        }

        private static System.Collections.IEnumerator Init()
        {
            while (NetworkManager.field_Internal_Static_NetworkManager_0 == null)
                yield return null;

            foreach (var module in modules)
                NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0.field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<VRC.Player>)delegate (VRC.Player player)
                {
                    if (player != null)
                        module.GetMethod("OnPlayerJoin").Invoke(module, new object[] { player });
                });

            foreach (var module in modules)
                NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1.field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<VRC.Player>)delegate (VRC.Player player)
                {
                    if (player != null)
                        module.GetMethod("OnPlayerLeave").Invoke(module, new object[] { player });
                });
        }

        public override void OnUpdate()
        {
            foreach (var module in modules)
                module.GetMethod("OnUpdate").Invoke(module, null);
        }

        public override void OnLateUpdate()
        {
            foreach (var module in modules)
                module.GetMethod("OnLateUpdate").Invoke(module, null);
        }

        public override void OnFixedUpdate()
        {
            foreach (var module in modules)
                module.GetMethod("OnFixedUpdate").Invoke(module, null);
        }

        public override void OnGUI()
        {
            foreach (var module in modules)
                module.GetMethod("OnGUI").Invoke(module, null);
        }

        public override void OnApplicationQuit()
        {
            foreach (var module in modules)
                module.GetMethod("OnQuit").Invoke(module, null);
        }
    }
}
