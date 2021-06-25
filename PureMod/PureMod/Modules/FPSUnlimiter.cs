using PureModLoader.API;
using UnityEngine;

namespace PureMod.Modules
{
    [Module]
    public class FPSUnlimiter
    {
        public int loadOrder = 1;
        public string moduleName = "FPS Unlimiter";

        public void OnStart() =>
            Application.targetFrameRate = 300;
    }
}
