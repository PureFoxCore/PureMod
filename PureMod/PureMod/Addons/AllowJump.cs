using PureMod.API;

namespace PureMod.Addons
{
    public class AllowJump : ModSystem
    {
        public override int LoadOrder => 2;
        public override string ModName => "AllowJump";

        public override void OnStart()
        {
            new ButtonAPI.SingleButton(QMmenu.mainMenuP1.GetMenuName(), 2, 0, true, "Add Jump", "Add jump on this map", delegate ()
            {
                if (Utils.GetLocalPlayer().gameObject.GetComponent<PlayerModComponentJump>())
                    return;

                var jumpComponent = Utils.GetLocalPlayer().gameObject.AddComponent<PlayerModComponentJump>();
                jumpComponent.field_Private_Single_0 = 5;
                jumpComponent.field_Private_Single_1 = 5;

                Utils.CoreLogger.Info("Jump added!");
            });
        }
    }
}
