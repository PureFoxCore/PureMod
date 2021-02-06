using System;
using UnityEngine;
using UnityEngine.UI;

namespace PureMod.API.ButtonAPI
{
    public class QuickMenuToggleButton : QuickMenuButtonBase
    {
        public bool m_State { get; private set; }

        public QuickMenuToggleButton(QuickMenuNestedButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action<bool> action, bool state = false, Color? textColorOn = null, Color? textColorOff = null, Color? backgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, action, state, backgroundColor, textColorOn, textColorOff);
        }

        public QuickMenuToggleButton(QuickMenuNestedHalfButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action<bool> action, bool state = false, Color? textColorOn = null, Color? textColorOff = null, Color? backgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, action, state, backgroundColor, textColorOn, textColorOff);
        }

        public QuickMenuToggleButton(string buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action<bool> action, bool state = false, Color? textColorOn = null, Color? textColorOff = null, Color? backgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu;
            initializeButton(xLocation, yLocation, text, toolTip, action, state, backgroundColor, textColorOn, textColorOff);
        }

        private void initializeButton(int xLocation, int yLocation, string text, string toolTip, Action<bool> action, bool state, Color? backgroundColor = null, Color? textColorOn = null, Color? textColorOff = null)
        {
            buttonType = "ToggleButton";
            button = UnityEngine.Object.Instantiate(s_SingleButton, s_QuickMenu.transform.Find(buttonQuickMenuLocation), true);

            initShift[0] = -1;
            initShift[1] = 0;

            SetLocation(xLocation, yLocation);
            SetButtonText(text);
            SetToolTip(toolTip);
            SetButtonAction(action, textColorOn != null ? (Color)textColorOn : OriginalTextColor, textColorOff != null ? (Color)textColorOff : OriginalTextColor);

            m_State = state;

            if (backgroundColor != null)
                SetBackgroundColor((Color)backgroundColor);
            else
                OriginalBackgroundColor = button.GetComponentInChildren<Image>().color;

            if (state && textColorOn != null)
                SetTextColor((Color)textColorOn);
            else if (!state && textColorOff != null)
                SetTextColor((Color)textColorOff);

            else
                OriginalTextColor = button.GetComponentInChildren<Text>().color;

            SetActive(true);
        }

        public void SetButtonText(string text) =>
            button.GetComponentInChildren<Text>().text = text;

        public void SetButtonAction(Action<bool> action, Color colorOn, Color colorOff)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

            if (action != null)
            {
                button.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    m_State = !m_State;
                    SetTextColor(m_State ? colorOn : colorOff);
                    action.Invoke(m_State);
                }));
            }
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
