﻿using UnityEngine;
using PureMod.API;
using PureModLoader.API;
using System.Diagnostics;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    public class QuitGame : ModSystem
    {
        public override int LoadOrder => 1;
        public override string ModName => "Quit Game";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 1, true, "Quit", "ShutDown Game", delegate ()
             {
                 PopupAPI.CreateConfirmPopup("Quit?", "Are you sure to quit game?\nIt will kill game prosess", "Yes", "No", delegate ()
                 {
                     Process.GetCurrentProcess().Kill();
                 }, null, null, Color.red, Color.white, Color.red, Color.white);
             }, Color.red);
        }
    }
}
