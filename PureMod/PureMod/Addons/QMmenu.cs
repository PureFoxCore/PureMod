using PureMod.API;

namespace PureMod.Addons
{
    public class QMmenu : ModSystem
    {
        public override int LoadOrder => 0;
        public override bool ShowName => false;

        public static ButtonAPI.NestedButton mainMenuP1;
        public static ButtonAPI.NestedButton mainMenuP2;
        public static ButtonAPI.NestedButton mainMenuP3;

        public override void OnStart()
        {
            mainMenuP1 = new ButtonAPI.NestedButton("ShortcutMenu", 0, -1, false, "PureMod", "Pure Mod Menu");
            mainMenuP2 = new ButtonAPI.NestedButton(mainMenuP1.GetMenuName(), 5, 4, true, "Page 2", "Pure Mod Menu Page 2");
            mainMenuP3 = new ButtonAPI.NestedButton(mainMenuP2.GetMenuName(), 5, 4, true, "Page 3", "Pure Mod Menu Page 3");
        }
    }
}
