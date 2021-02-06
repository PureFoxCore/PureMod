using UnityEngine;
using PureMod.API;
using PureMod.API.Logger;

namespace PureMod.Addons
{
    public class EarRape : ModSystem
    {
        public override string ModName => "EarRape";

        private bool EarRapeState = false;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F9))
            {
                EarRapeState = !EarRapeState;
                Utils.GetLocalPlayer().SetVoiceGain(EarRapeState ? float.MaxValue / 2f : 1f);
                Utils.GetLocalPlayer().SetAvatarAudioGain(EarRapeState ? float.MaxValue / 2f : 1f);
                Core.CoreLogger.Log(EarRapeState ? "EarRape Enabled!" : "EarRape Disabled", EarRapeState ? LogLevel.Critical : LogLevel.Info);
            }
        }
    }
}
