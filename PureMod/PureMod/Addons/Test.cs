using UnityEngine;
using PureMod.API;
using UnhollowerRuntimeLib;

namespace PureMod.Addons
{
    public class Test : ModSystem
    {
        public override int LoadOrder => 7;
        public override bool ShowName => false;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                foreach (var component in Utils.GetLocalPlayer().gameObject.GetComponents(Il2CppType.Of<Component>()))
                    Utils.CoreLogger.Trace(component.GetIl2CppType().ToString());
            }
        }
    }
}
