using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;
using UnityEngine;

namespace PureMod.Modules
{
    [Module]
    public class EarRape
    {
        public int loadOrder = 1;
        public string moduleName = "EarRape";

        public void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.MenuPath, 1, 3, true, moduleName, "Pls don't use this", delegate (bool state)
            {
                //USpeaker.field_Internal_Static_Single_0 = state ? float.MaxValue : 1f; UR EARS
                USpeaker.field_Internal_Static_Single_1 = state ? float.MaxValue : 1f;
            }, Color.red, Color.white);
        }
    }
}
