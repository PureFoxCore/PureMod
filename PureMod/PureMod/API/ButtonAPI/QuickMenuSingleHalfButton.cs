using System;
using UnityEngine;
using UnityEngine.UI;

namespace PureMod.API.ButtonAPI
{
    public class QuickMenuSingleHalfButton : QuickMenuHalfButtonBase
    {
        public QuickMenuSingleHalfButton(QuickMenuNestedButton buttonMenu, int xLocation, int yLocation, string text, Action action, string toolTip, Color? backgroundColor = null, Color? textColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, action, toolTip, backgroundColor, textColor);
        }

        public QuickMenuSingleHalfButton(QuickMenuNestedHalfButton buttonMenu, int xLocation, int yLocation, string text, Action action, string toolTip, Color? backgroundColor = null, Color? textColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, action, toolTip, backgroundColor, textColor);
        }

        public QuickMenuSingleHalfButton(string buttonMenu, int xLocation, int yLocation, string text, Action action, string toolTip, Color? backgroundColor = null, Color? textColor = null)
        {
            buttonQuickMenuLocation = buttonMenu;
            initializeButton(xLocation, yLocation, text, action, toolTip, backgroundColor, textColor);
        }

        private void initializeButton(int xLocation, int yLocation, string text, Action action, string toolTip, Color? backgroundColor = null, Color? textColor = null)
        {
            buttonType = "SingleButton";
            button = UnityEngine.Object.Instantiate(s_SingleButton, s_QuickMenu.transform.Find(buttonQuickMenuLocation), true);

            initShift[0] = -1;
            initShift[1] = 0;

            SetLocation(xLocation, yLocation);
            SetButtonText(text);
            SetToolTip(toolTip);
            SetButtonAction(action);

            if (backgroundColor != null)
                SetBackgroundColor((Color)backgroundColor);
            else
                OriginalBackgroundColor = button.GetComponentInChildren<Image>().color;

            if (textColor != null)
                SetTextColor((Color)textColor);
            else
                OriginalTextColor = button.GetComponentInChildren<Text>().color;

            SetActive(true);
        }

        public void SetButtonText(string text) =>
            button.GetComponentInChildren<Text>().text = text;

        public void SetButtonAction(Action action)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

            if (action != null)
                button.GetComponent<Button>().onClick.AddListener(action);
        }

        public override void SetTextColor(Color color, bool save = true)
        {
            button.GetComponentInChildren<Text>().color = color;

            if (save)
                OriginalTextColor = color;
        }

        public override void SetBackgroundColor(Color color, bool save = true)
        {
            if (save)
                OriginalBackgroundColor = color;

            button.GetComponentInChildren<Button>().colors = new ColorBlock()
            {
                colorMultiplier = 1f,
                disabledColor = Color.gray,
                highlightedColor = color * 1.5f,
                normalColor = color / 1.5f,
                pressedColor = Color.gray
            };
        }
    }
}
