using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class QuickMenuMenu : ModSystem
    {
        public override bool ShowName => false;

        public static QuickMenuNestedButton mainMenuP1;
        public static QuickMenuNestedButton mainMenuP2;

        public override void OnStart()
        {
            mainMenuP1 = new QuickMenuNestedButton("ShortcutMenu", 0, -1, "Pure\nMod", "Pure Mod Menu");
            mainMenuP2 = new QuickMenuNestedButton(mainMenuP1.menuName, 5, 1, "Page 2", "Pure Mod Menu Page 2");

            Core.CoreLogger.Trace(mainMenuP1.menuName);
            Core.CoreLogger.Trace(mainMenuP2.menuName);
        }
    }
}
