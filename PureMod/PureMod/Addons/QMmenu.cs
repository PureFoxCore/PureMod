using PureMod.API;
using UnityEngine;
using UnityEngine.UI;

namespace PureMod.Addons
{
    public class QMmenu : ModSystem
    {
        public override int LoadOrder => 0;
        public override bool ShowName => false;

        public static ButtonAPI.NestedButton mainMenuP1;
        public static ButtonAPI.NestedButton mainMenuP2;
        public static ButtonAPI.NestedButton mainMenuP3;

        public static ButtonAPI.NestedButton userMenuP1;
        public static ButtonAPI.NestedButton userMenuP2;
        public static ButtonAPI.NestedButton userMenuP3;

        private GameObject cloneButton;

        public override void OnStart()
        {
            cloneButton = GameObject.Find("UserInterface/QuickMenu/UserInteractMenu/CloneAvatarButton");

            mainMenuP1 = new ButtonAPI.NestedButton("ShortcutMenu", 0, -1, false, "PureMod", "Pure Mod Menu");
            mainMenuP2 = new ButtonAPI.NestedButton(mainMenuP1.GetMenuName(), 5, 4, true, "Page 2", "Pure Mod Menu Page 2");
            mainMenuP3 = new ButtonAPI.NestedButton(mainMenuP2.GetMenuName(), 5, 4, true, "Page 3", "Pure Mod Menu Page 3");

            userMenuP1 = new ButtonAPI.NestedButton("UserInteractMenu", 5, 0, false, "PureMod\nUtils", "PureMod Utils");
            userMenuP2 = new ButtonAPI.NestedButton(userMenuP1.GetMenuName(), 5, 4, true, "Page 2", "User Utils Menu Page 2");
            userMenuP3 = new ButtonAPI.NestedButton(userMenuP2.GetMenuName(), 5, 4, true, "Page 3", "User Utils Menu Page 3");
        }

        public override void OnLateUpdate()
        {
            if (cloneButton != null)
                cloneButton.SetActive(false);
        }
    }
}