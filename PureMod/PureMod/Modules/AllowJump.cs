using PureMod.API;
using PureMod.Other;
using PureModLoader.API;
using PureModLoader.UIAPI.QM;

namespace PureMod.Modules
{
    public class AllowJump : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "AllowJump";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.GetMenuName(), 2, 0, true, "Add Jump", "Add jump on this map", delegate ()
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
