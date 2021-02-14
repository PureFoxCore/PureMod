using UnityEngine;
using VRC.SDKBase;
using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class MirrorOptimize : ModSystem
    {
        public override int LoadOrder => 10;
        public override string ModName => "Mirror Quality";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 2, 1, true, "Mirror Q.", "Mirror Toggle Quality", delegate (bool state)
            {
                LayerMask mask = new LayerMask();
                mask.value = state ? 263680 : -1025;

                VRCSDK2.VRC_MirrorReflection[] array2 = Object.FindObjectsOfType<VRCSDK2.VRC_MirrorReflection>();
                for (int i = 0; i < array2.Length; i++)
                    array2[i].m_ReflectLayers = mask;

                VRC_MirrorReflection[] array4 = Object.FindObjectsOfType<VRC_MirrorReflection>();
                for (int i = 0; i < array4.Length; i++)
                    array4[i].m_ReflectLayers = mask;

                Utils.CoreLogger.Info(state ? "Mirror quality set to max" : "Mirror quality set to min");
            }, Color.green, Color.white);
        }
    }
}
