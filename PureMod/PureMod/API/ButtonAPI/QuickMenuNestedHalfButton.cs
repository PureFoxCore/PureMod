using System;
using UnityEngine;
using System.Linq;
using UnhollowerRuntimeLib;
using Il2CppSystem.Reflection;

namespace PureMod.API.ButtonAPI
{
    public class QuickMenuNestedHalfButton
    {
        public string menuName { get; private set; }
        public QuickMenuSingleHalfButton mainButton;
        public QuickMenuSingleHalfButton backButton;

        protected Transform s_NestedButton { get { return GameObject.Find("UserInterface/QuickMenu/CameraMenu").transform; } }
        protected string buttonQuickMenuLocation;
        protected string ButtonType;

        private FieldInfo currentPageGetter;

        public QuickMenuNestedHalfButton(QuickMenuNestedButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, mainTextColor, mainBackgroundColor, backTextColor, backBackgroundColor);
        }

        public QuickMenuNestedHalfButton(QuickMenuNestedHalfButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, mainTextColor, mainBackgroundColor, backTextColor, backBackgroundColor);
        }

        public QuickMenuNestedHalfButton(string buttonMenu, int xLocation, int yLocation, string text, string toolTip, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu;
            initializeButton(xLocation, yLocation, text, toolTip, mainTextColor, mainBackgroundColor, backTextColor, backBackgroundColor);
        }

        public QuickMenuNestedHalfButton(QuickMenuNestedButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action action, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, mainTextColor, mainBackgroundColor, backTextColor, backBackgroundColor, action);
        }

        public QuickMenuNestedHalfButton(QuickMenuNestedHalfButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action action, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, mainTextColor, mainBackgroundColor, backTextColor, backBackgroundColor, action);
        }

        public QuickMenuNestedHalfButton(string buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action action, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu;
            initializeButton(xLocation, yLocation, text, toolTip, mainTextColor, mainBackgroundColor, backTextColor, backBackgroundColor, action);
        }

        private void initializeButton(int xLocation, int yLocation, string text, string toolTip, Color? mainTextColor = null, Color? mainBackgroundColor = null, Color? backTextColor = null, Color? backBackgroundColor = null, Action action = null)
        {
            ButtonType = "NestedButton";

            Transform menu = UnityEngine.Object.Instantiate<Transform>(s_NestedButton, QuickMenuButtonBase.s_QuickMenu.transform);
            menuName = $"{QuickMenuButtonBase.Identifer}{buttonQuickMenuLocation}_{xLocation}_{yLocation}";
            menu.name = menuName;

            mainButton = new QuickMenuSingleHalfButton(buttonQuickMenuLocation, xLocation, yLocation, text, delegate ()
            {
                if (action != null)
                    action.Invoke();
                ShowQuickMenuPage(menuName);
            }, toolTip, mainBackgroundColor, mainTextColor);

            Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Il2CppSystem.Object obj = enumerator.Current;
                Transform buttonEnum = obj.Cast<Transform>();
                if (buttonEnum != null)
                    UnityEngine.Object.Destroy(buttonEnum.gameObject);
            }

            if (backTextColor == null)
                backTextColor = Color.yellow;

            backButton = new QuickMenuSingleHalfButton(this, 5, 5, "Back", delegate ()
            {
                ShowQuickMenuPage(buttonQuickMenuLocation);
            }, "Go Back", backBackgroundColor, backTextColor);
        }

        private void ShowQuickMenuPage(string pagename)
        {
            QuickMenu quickmenu = QuickMenuButtonBase.s_QuickMenu;
            Transform pageTransform = quickmenu?.transform.Find(pagename);

            if (pageTransform == null)
                Core.CoreLogger.Critical("pageTransform is null !");

            if (currentPageGetter == null)
            {
                GameObject shortcutMenu = quickmenu.transform.Find("ShortcutMenu").gameObject;
                if (!shortcutMenu.activeInHierarchy)
                    shortcutMenu = quickmenu.transform.Find("UserInteractMenu").gameObject;


                FieldInfo[] fis = Il2CppType.Of<QuickMenu>().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where((fi) => fi.FieldType == Il2CppType.Of<GameObject>()).ToArray();
                int count = 0;
                foreach (FieldInfo fi in fis)
                {
                    GameObject value = fi.GetValue(quickmenu)?.TryCast<GameObject>();
                    if (value == shortcutMenu && ++count == 2)
                    {
                        currentPageGetter = fi;
                        break;
                    }
                }
                if (currentPageGetter == null)
                {
                    Core.CoreLogger.Critical("Unable to find field currentPage in QuickMenu");
                    return;
                }
            }

            currentPageGetter.GetValue(quickmenu)?.Cast<GameObject>().SetActive(false);

            GameObject infoBar = quickmenu.transform.Find("QuickMenu_NewElements/_InfoBar").gameObject;
            infoBar.SetActive(pagename == "ShortcutMenu");

            QuickMenuContextualDisplay quickmenuContextualDisplay = quickmenu.field_Private_QuickMenuContextualDisplay_0;
            quickmenuContextualDisplay.Method_Public_Void_EnumNPublicSealedvaUnNoToUs7vUsNoUnique_0(QuickMenuContextualDisplay.EnumNPublicSealedvaUnNoToUs7vUsNoUnique.NoSelection);

            pageTransform.gameObject.SetActive(true);

            currentPageGetter.SetValue(quickmenu, pageTransform.gameObject);

            if (pagename == "ShortcutMenu")
                SetIndex(0);
            else if (pagename == "UserInteractMenu")
                SetIndex(3);
            else
            {
                SetIndex(-1);
                QuickMenuButtonBase.s_QuickMenu.transform.Find("ShortcutMenu").gameObject?.SetActive(false);
                QuickMenuButtonBase.s_QuickMenu.transform.Find("UserInteractMenu").gameObject?.SetActive(false);
            }
        }

        private void SetIndex(int index) =>
            QuickMenuButtonBase.s_QuickMenu.field_Private_Int32_0 = index;
    }
}
