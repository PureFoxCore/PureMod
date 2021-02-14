using UnityEngine;
using PureMod.API;
using System.Diagnostics;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class QuitGame : ModSystem
    {
        public override int LoadOrder => 12;
        public override string ModName => "Quit Game";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 1, true, "Quit", "ShutDown Game", delegate ()
             {
                 Process.GetCurrentProcess().Kill();
             }, Color.red);
        }
    }
}
