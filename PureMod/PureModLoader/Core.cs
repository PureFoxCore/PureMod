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

        private static List<ModuleBase> Modules = new List<ModuleBase>();

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
                        if (type.IsSubclassOf(typeof(ModuleBase)))
                            Modules.Add((ModuleBase)Activator.CreateInstance(type));

                    Modules = Modules.OrderBy(owo => owo.LoadOrder).ToList();
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
                    CoreLogger.Trace($"{module.ModuleName} loaded!");

                module.OnEarlierStart();
            }
            CoreLogger.Info($"Loaded {Modules.Count} modules!");
        }

        public override void VRChat_OnUiManagerInit()
        {
            new System.Threading.Timer((e) =>
            {
                foreach (ModuleBase module in Modules)
                    module.OnUpdate10();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            new System.Threading.Timer((e) =>
            {
                foreach (ModuleBase module in Modules)
                    module.OnUpdate1();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            foreach (ModuleBase module in Modules)
                module.OnStart();

            MelonCoroutines.Start(Init());
        }

        private static System.Collections.IEnumerator Init()
        {
            while (NetworkManager.field_Internal_Static_NetworkManager_0 == null)
                yield return null;

            foreach (ModuleBase module in Modules)
                NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0.field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<VRC.Player>)delegate (VRC.Player player)
                {
                    if (player != null)
                        module.OnPlayerJoin(player);
                });

            foreach (ModuleBase module in Modules)
                NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1.field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<VRC.Player>)delegate (VRC.Player player)
                {
                    if (player != null)
                        module.OnPlayerLeave(player);
                });
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
