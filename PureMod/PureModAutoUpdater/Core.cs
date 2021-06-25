using System;
using System.IO;
using System.Net;
using MelonLoader;

namespace PureModAutoUpdater
{
    public class Core : MelonPlugin
    {
        public override void OnApplicationEarlyStart()
        {
            WebClient client = new WebClient();

            string loaderPath = $"{Environment.CurrentDirectory}\\Mods\\";
            string loaderFile = $"{loaderPath}\\PureModLoader.dll";

            string modulesPath = $"{Environment.CurrentDirectory}\\PureMod\\Modules";
            string modFile = $"{modulesPath}\\PureMod.dll";

            if (!Directory.Exists(loaderPath))
                Directory.CreateDirectory(loaderPath);

            if (!Directory.Exists(modulesPath))
                Directory.CreateDirectory(modulesPath);

            if (File.Exists(loaderFile))
                File.Delete(loaderFile);

            if (File.Exists(modFile))
                File.Delete(modFile);

            client.DownloadFile(new Uri("https://github.com/PureFoxCore/PureMod/releases/latest/download/PureModLoader.dll"), loaderFile);
            client.DownloadFile(new Uri("https://github.com/PureFoxCore/PureMod/releases/latest/download/PureMod.dll"), modFile);
        }
    }
}
