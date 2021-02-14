using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class PlayerList : ModSystem
    {
        public override int LoadOrder => 20;

        public override string ModName => "Player list";

        public override void OnStart()
        {
            new NestedButton(QMmenu.mainMenuP1.GetMenuName(), 4, 2, true, "Players", "Player list", delegate()
            {

            });
        }
    }
}
