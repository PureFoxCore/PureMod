using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;
using UnityEngine;

namespace PureMod.Modules
{
    public class EarRape : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "EarRape";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.MenuPath, 1, 3, true, ModuleName, "Pls don't use this", delegate (bool state)
            {
                //USpeaker.field_Internal_Static_Single_0 = state ? float.MaxValue : 1f; UR EARS
                USpeaker.field_Internal_Static_Single_1 = state ? float.MaxValue : 1f;
            }, Color.red, Color.white);
        }
    }
}
