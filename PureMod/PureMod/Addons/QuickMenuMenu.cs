using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class QuickMenuMenu : ModSystem
    {
        public override bool ShowName => false;

        public static QuickMenuNestedButton mainMenuP1;
        public static QuickMenuNestedHalfButton mainMenuP2;
        public static QuickMenuNestedHalfButton mainMenuP3;

        public override void OnStart()
        {
            mainMenuP1 = new QuickMenuNestedButton("ShortcutMenu", 0, -1, "Pure\nMod", "Pure Mod Menu");
            mainMenuP2 = new QuickMenuNestedHalfButton(mainMenuP1.menuName, 5, 3, "Page 2", "Pure Mod Menu Page 2");
            mainMenuP3 = new QuickMenuNestedHalfButton(mainMenuP1.menuName, 5, 4, "Page 3", "Pure Mod Menu Page 3");
        }
    }
}
