using PureMod.API;
using UnityEngine;

namespace PureMod.Modules
{
    public class FPSUnlimiter : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "FPS Unlimiter";

        public override void OnStart() =>
            Application.targetFrameRate = 300;
    }
}
