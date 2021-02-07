using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class AllowJump : ModSystem
    {
        public override string ModName => "AllowJump";

        public override void OnStart()
        {
            new QuickMenuSingleHalfButton(QuickMenuMenu.mainMenuP1, 1, 0, "Add Jump", delegate ()
            {
                if (Utils.GetLocalPlayer().gameObject.GetComponent<PlayerModComponentJump>())
                    return;

                var jumpComponent = Utils.GetLocalPlayer().gameObject.AddComponent<PlayerModComponentJump>();
                jumpComponent.field_Private_Single_0 = 5;
                jumpComponent.field_Private_Single_1 = 5;
            }, "Add jump on this map");
        }
    }
}
