using System;
using System.IO;
using UnityEngine;
using PureMod.API;
using UnityEngine.UI;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class QMmenu : ModSystem
    {
        public override int LoadOrder => 0;
        public override bool ShowName => false;

        public static NestedButton mainMenuP1;
        public static NestedButton mainMenuP2;
        public static NestedButton mainMenuP3;

        public override void OnStart()
        {
            mainMenuP1 = new NestedButton("ShortcutMenu", 0, -1, false, "PureMod", "Pure Mod Menu");
            mainMenuP2 = new NestedButton(mainMenuP1.GetMenuName(), 5, 4, true, "Page 2", "Pure Mod Menu Page 2");
            mainMenuP3 = new NestedButton(mainMenuP2.GetMenuName(), 5, 4, true, "Page 3", "Pure Mod Menu Page 3");

            //if (File.Exists(Path.Combine(Environment.CurrentDirectory, "PureMod\\Logo.png")))
            //{
            //    byte[] fileData = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "PureMod\\Logo.png"));
            //    Texture2D tex = new Texture2D(4096, 4096);
            //    //if (tex.LoadImage(FileData))
            //    mainMenuP1.GetMainButton().Button.gameObject.GetComponent<Image>();
            //}
        }
    }
}
