using System;
using UnityEngine;
using PureModLoader.API;
using System.Collections.Generic;

namespace PureMod.Modules
{
    public class MGUI : ModuleBase
    {
        public override int LoadOrder => 0;
        public override string ModuleName => "GUI";

        private static Rect windowRect = new Rect(GetScreenWidth(2), GetScreenHeight(68), GetScreenWidth(20), GetScreenHeight(30));
        private static List<string> texts = new List<string>();

        public override void OnStart()
        {
            new System.Threading.Timer((e) =>
            {
                Clear();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(300));
        }

        public override void OnGUI()
        {
            windowRect = GUI.Window(1, windowRect, (GUI.WindowFunction)WindowFunc, "PureMod Console");
        }

        public static int GetScreenWidth(int percentage) => (Screen.width * percentage) / 100;
        public static int GetScreenHeight(int percentage) => (Screen.height * percentage) / 100;

        private void WindowFunc(int windowID)
        {
            for (int i = 0; i < texts.Count; i++)
                GUI.Label(new Rect(10, (15 * i) + 15, GetScreenWidth(20), 30), texts[i]);
        }

        public static void Clear() =>
            texts.Clear();

        public static void LogText(string text) =>
            texts.Add(text);
    }
}
