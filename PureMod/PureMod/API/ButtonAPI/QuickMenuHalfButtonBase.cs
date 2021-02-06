using UnityEngine;
using UnityEngine.UI;

namespace PureMod.API.ButtonAPI
{
    public class QuickMenuHalfButtonBase
    {
        public static QuickMenu s_QuickMenu { get { return GameObject.Find("UserInterface/QuickMenu").GetComponent<QuickMenu>(); } }
        public const string Identifer = "PureMenu";

        protected static GameObject s_SingleButton { get { return GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/WorldsButton"); } }
        protected static GameObject s_ToggleButton { get { return GameObject.Find("UserInterface/QuickMenu/UserInteractMenu/BlockButton"); } }

        protected GameObject button;
        protected string buttonTag;
        protected string buttonQuickMenuLocation;
        protected string buttonType;
        protected int[] initShift = { 0, 0 };
        protected Color OriginalBackgroundColor;
        protected Color OriginalTextColor;

        public GameObject GetGameObject()
        {
            return button;
        }

        public void SetActive(bool state) =>
            button.gameObject.SetActive(state);

        public void SetInteractable(bool state)
        {
            if (state)
            {
                SetBackgroundColor(OriginalBackgroundColor, false);
                SetTextColor(OriginalTextColor, false);
            }
            else
            {
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1f), false);
                SetTextColor(new Color(0.7f, 0.7f, 0.7f, 1f), false);
            }

            button.GetComponent<Button>().interactable = state;
        }

        public void SetLocation(int xLoc, int yLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (xLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (210 * (yLoc + initShift[1] - 0.5f));

            button.GetComponent<RectTransform>().sizeDelta = new Vector2(button.GetComponent<RectTransform>().sizeDelta.x, button.GetComponent<RectTransform>().sizeDelta.y / 2);

            buttonTag = "(" + xLoc + ", " + yLoc + ")";
            button.name = buttonQuickMenuLocation + "/" + buttonType + buttonTag;
            button.GetComponent<Button>().name = buttonType + buttonTag;
        }

        public void SetToolTip(string buttonToolTip) =>
            button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;

        public void Destroy() =>
            UnityEngine.Object.Destroy(button);

        public virtual void SetBackgroundColor(Color color, bool save = true) { }
        public virtual void SetTextColor(Color color, bool save = true) { }
    }
}
