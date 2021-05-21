using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using PureModLoader.API;
using UnhollowerRuntimeLib;
using Il2CppSystem.Reflection;

namespace PureModLoader.ButtonAPI
{
    public class ButtonBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;
        protected Color OrigText;

        public GameObject getGameObject() =>
            button;

        public void SetActive(bool isActive) =>
            button.gameObject.SetActive(isActive);

        public void SetIntractable(bool isIntractable)
        {
            if (isIntractable)
            {
                SetBackgroundColor(OrigBackground, false);
                SetTextColor(OrigText, false);
            }
            else
            {
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1), false);
                SetTextColor(new Color(0.7f, 0.7f, 0.7f, 1), false); ;
            }
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        public void SetLocation(int buttonXLoc, int buttonYLoc, bool half = false)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * ((half ? 210 : 420) * (buttonYLoc + initShift[1] - (half ? 0.5f : 0.0f)));

            button.GetComponent<RectTransform>().sizeDelta = new Vector2(button.GetComponent<RectTransform>().sizeDelta.x, half ? button.GetComponent<RectTransform>().sizeDelta.y / 2 : button.GetComponent<RectTransform>().sizeDelta.y);

            btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        public void SetToolTip(string buttonToolTip) =>
            button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;

        public void Destroy() =>
            Object.Destroy(button);

        public virtual void SetBackgroundColor(Color buttonBackgroundColor, bool save = true) { }
        public virtual void SetTextColor(Color buttonTextColor, bool save = true) { }
    }
    public class QMStuff
    {
        private static BoxCollider QuickMenuBackgroundReference;
        private static GameObject SingleButtonReference;
        private static GameObject ToggleButtonReference;
        private static Transform NestedButtonReference;
        private static QuickMenu quickmenuInstance;
        private static VRCUiManager vrcuimInstance;

        public static BoxCollider QuickMenuBackground()
        {
            if (QuickMenuBackgroundReference == null)
                QuickMenuBackgroundReference = GetQuickMenuInstance().GetComponent<BoxCollider>();
            return QuickMenuBackgroundReference;
        }

        public static GameObject SingleButtonTemplate()
        {
            if (SingleButtonReference == null)
                SingleButtonReference = GetQuickMenuInstance().transform.Find("ShortcutMenu/WorldsButton").gameObject;
            return SingleButtonReference;
        }

        public static GameObject ToggleButtonTemplate()
        {
            if (ToggleButtonReference == null)
                ToggleButtonReference = GetQuickMenuInstance().transform.Find("UserInteractMenu/BlockButton").gameObject;
            return ToggleButtonReference;
        }

        public static Transform NestedMenuTemplate()
        {
            if (NestedButtonReference == null)
                NestedButtonReference = GetQuickMenuInstance().transform.Find("CameraMenu");
            return NestedButtonReference;
        }

        public static QuickMenu GetQuickMenuInstance()
        {
            if (quickmenuInstance == null)
                quickmenuInstance = QuickMenu.prop_QuickMenu_0;
            return quickmenuInstance;
        }

        public static VRCUiManager GetVRCUiMInstance()
        {
            if (vrcuimInstance == null)
                vrcuimInstance = VRCUiManager.prop_VRCUiManager_0;
            return vrcuimInstance;
        }

        private static FieldInfo currentPageGetter;
        private static GameObject shortcutMenu;
        private static GameObject userInteractMenu;

        public static void ShowQuickmenuPage(string pagename)
        {
            QuickMenu quickmenu = GetQuickMenuInstance();
            Transform pageTransform = quickmenu?.transform.Find(pagename);
            if (pageTransform == null)
                Utils.CoreLogger.Critical("pageTransform is null !");

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
                    Utils.CoreLogger.Critical("Unable to find field currentPage in QuickMenu");
                    return;
                }
            }

            currentPageGetter.GetValue(quickmenu)?.Cast<GameObject>().SetActive(false);

            GameObject infoBar = GetQuickMenuInstance().transform.Find("QuickMenu_NewElements/_InfoBar").gameObject;
            infoBar.SetActive(pagename == "ShortcutMenu");

            QuickMenuContextualDisplay quickmenuContextualDisplay = GetQuickMenuInstance().field_Private_QuickMenuContextualDisplay_0;
            quickmenuContextualDisplay.Method_Public_Void_EnumNPublicSealedvaUnNoToUs7vUsNoUnique_0(QuickMenuContextualDisplay.EnumNPublicSealedvaUnNoToUs7vUsNoUnique.NoSelection);

            pageTransform.gameObject.SetActive(true);

            currentPageGetter.SetValue(quickmenu, pageTransform.gameObject);

            if (shortcutMenu == null)
                shortcutMenu = QuickMenu.prop_QuickMenu_0.transform.Find("ShortcutMenu")?.gameObject;

            if (userInteractMenu == null)
                userInteractMenu = QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu")?.gameObject;

            if (pagename == "ShortcutMenu")
            {
                SetIndex(0);
            }
            else if (pagename == "UserInteractMenu")
            {
                SetIndex(3);
            }
            else
            {
                SetIndex(-1);
                shortcutMenu?.SetActive(false);
                userInteractMenu?.SetActive(false);
            }
        }

        public static void SetIndex(int index) =>
            GetQuickMenuInstance().field_Private_Int32_0 = index;
    }
}