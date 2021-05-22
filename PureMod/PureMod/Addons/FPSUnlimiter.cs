using PureMod.API;
using UnityEngine;

namespace PureMod.Addons
{
    public class FPSUnlimiter : ModBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "FPS Unlimiter";

        public override void OnStart() =>
            Application.targetFrameRate = 300;
    }
}
