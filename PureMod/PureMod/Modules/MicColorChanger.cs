using System;
using UnityEngine;
using PureModLoader.API;
using UnityEngine.UI;
using PureMod.Config;

namespace PureMod.Modules
{
    public class MicColorChanger : ModuleBase
    {
        public override int LoadOrder => 0;
        public override string ModuleName => "Microphone color changer";

        public static Color imageColor;

        public override void OnStart()
        {
            imageColor = ModColors.DefaultMicColor;
            GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDot").GetComponent<Image>().color = imageColor;
            GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>().color = imageColor;
        }

    }
}
