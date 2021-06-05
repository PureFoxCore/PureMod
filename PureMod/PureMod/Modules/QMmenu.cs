using PureModLoader.API;
using UnityEngine;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    public class QMmenu : ModuleBase
    {
        public override int LoadOrder => 0;
        public override bool ShowName => false;

        public static NestedButton mainMenuP1;
        public static NestedButton mainMenuP2;
        public static NestedButton mainMenuP3;

        public static NestedButton userMenuP1;
        public static NestedButton userMenuP2;
        public static NestedButton userMenuP3;

        private GameObject cloneButton;

        public override void OnStart()
        {
            cloneButton = GameObject.Find("UserInterface/QuickMenu/UserInteractMenu/CloneAvatarButton");

            mainMenuP1 = new NestedButton("ShortcutMenu", 0, -1, false, "PureMod", "Pure Mod Menu");
            mainMenuP2 = new NestedButton(mainMenuP1.MenuPath, 5, 4, true, "Page 2", "Pure Mod Menu Page 2");
            mainMenuP3 = new NestedButton(mainMenuP2.MenuPath, 5, 4, true, "Page 3", "Pure Mod Menu Page 3");

            userMenuP1 = new NestedButton("UserInteractMenu", 5, 0, false, "PureMod\nUtils", "PureMod Utils");
            userMenuP2 = new NestedButton(userMenuP1.MenuPath, 5, 4, true, "Page 2", "User Utils Menu Page 2");
            userMenuP3 = new NestedButton(userMenuP2.MenuPath, 5, 4, true, "Page 3", "User Utils Menu Page 3");
        }

        public override void OnLateUpdate()
        {
            if (cloneButton != null)
                cloneButton.SetActive(false);
        }
    }
}