using System;
using UnityEngine;
using PureModLoader.API;
using UnityEngine.UI;
using PureMod.Config;

namespace PureMod.Modules
{
    [Module]
    public class MicColorChanger
    {
        public int loadOrder = 0;
        public string moduleName = "Microphone color changer";

        public static Color imageColor;

        public void OnStart()
        {
            imageColor = ModColors.DefaultMicColor;
            GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDot").GetComponent<Image>().color = imageColor;
            GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>().color = imageColor;
        }

    }
}
