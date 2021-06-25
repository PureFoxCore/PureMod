using PureMod.Other;
using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class AllowJump
    {
        public int loadOrder = 1;
        public string moduleName = "AllowJump";

        public void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.MenuPath, 2, 0, true, "Add Jump", "Add jump on this map", delegate ()
            {
                if (Utils.LocalPlayer.gameObject.GetComponent<PlayerModComponentJump>())
                    return;

                var jumpComponent = Utils.LocalPlayer.gameObject.AddComponent<PlayerModComponentJump>();
                jumpComponent.field_Private_Single_0 = 5;
                jumpComponent.field_Private_Single_1 = 5;

                ModUtils.PureModLogger.Info("Jump added!");
            });
        }
    }
}
